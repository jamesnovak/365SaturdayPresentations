using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace MyXrmToolBoxPlugin
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetRoles);
        }

        private void GetRoles()
        {
            WorkAsync(new WorkAsyncInfo()
            {
                Message = "Retrieving Roles",
                AsyncArgument = null,
                Work = (worker, args) =>
                {
                    var QErole = new QueryExpression("role");

                    QErole.ColumnSet.AddColumns("name", "businessunitid", "roleid");

                    args.Result = Service.RetrieveMultiple(QErole);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;

                    // listBoxSecurityRoles.Items.Clear();
                    listBoxSecurityRoles.DataSource = null;

                    if (result != null)
                    {
                        var items = new List<ListBoxDisplayItem>();
                        foreach (var ent in result.Entities)
                        {
                            items.Add(new ListBoxDisplayItem((string)ent["name"], ent.Id.ToString()));
                        }
                        listBoxSecurityRoles.DataSource = items.OrderBy(e => e.Name).ToList();
                        listBoxSecurityRoles.DisplayMember = "Name";
                        listBoxSecurityRoles.ValueMember = "Value";
                    }
                }
            });
        }

        private class ListBoxDisplayItem
        {
            internal ListBoxDisplayItem(string name, string value)
            {
                _name = name;
                _value = value;
            }

            private string _name;
            private string _value;

            public string Name { get => _name; set => _name = value; }
            public string Value { get => _value; set => _value = value; }
        }
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void listBoxSecurityRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteMethod(LoadUsers);
        }

        private void LoadUsers()
        {
            var role = listBoxSecurityRoles.SelectedItem as ListBoxDisplayItem;

            if (role == null)
                return;

            var id = role.Value;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting System Users",
                AsyncArgument = id,
                Work = (worker, args) =>
                {
                    var roleId = (string)args.Argument;

                    // Instantiate QueryExpression QEsystemuser
                    var QEsystemuser = new QueryExpression("systemuser");

                    // Add columns to QEsystemuser.ColumnSet
                    QEsystemuser.ColumnSet.AddColumns("internalemailaddress", "lastname", "firstname", "domainname");

                    // Add link-entity QEsystemuser_systemuserroles
                    var QEsystemuser_systemuserroles = QEsystemuser.AddLink("systemuserroles", "systemuserid", "systemuserid");
                    QEsystemuser_systemuserroles.EntityAlias = "sur";

                    // Add link-entity QEsystemuser_systemuserroles_role
                    var QEsystemuser_systemuserroles_role = QEsystemuser_systemuserroles.AddLink("role", "roleid", "roleid");
                    QEsystemuser_systemuserroles_role.EntityAlias = "role";

                    // Add columns to QEsystemuser_systemuserroles_role.Columns
                    QEsystemuser_systemuserroles_role.Columns.AddColumns("name");

                    // Define filter QEsystemuser_systemuserroles_role.LinkCriteria
                    QEsystemuser_systemuserroles_role.LinkCriteria.AddCondition("roleid", ConditionOperator.Equal, roleId);


                    args.Result = Service.RetrieveMultiple(QEsystemuser);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message, "Oh crap", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (args.Result is EntityCollection views)
                    {
                        crmGridView.DataSource = views;
                    }
                }
            });
        }

        private void crmGridView_RecordClick(object sender, Cinteros.Xrm.CRMWinForm.CRMRecordEventArgs e)
        {
            if (e.Value is EntityReference entref)
            {
                OpenEntityReference(entref);
            }
        }

        private void crmGridView_RecordDoubleClick(object sender, Cinteros.Xrm.CRMWinForm.CRMRecordEventArgs e)
        {
            OpenEntityReference(e.Entity.ToEntityReference());
        }

        private void OpenEntityReference(EntityReference entref)
        {
            if (!string.IsNullOrEmpty(entref.LogicalName) && !entref.Id.Equals(Guid.Empty))
            {
                var url = ConnectionDetail.WebApplicationUrl;
                if (string.IsNullOrEmpty(url))
                {
                    url = string.Concat(ConnectionDetail.ServerName, "/", ConnectionDetail.Organization);
                    if (!url.ToLower().StartsWith("http"))
                    {
                        url = string.Concat("http://", url);
                    }
                }
                url = string.Concat(url,
                    url.EndsWith("/") ? "" : "/",
                    "main.aspx?etn=",
                    entref.LogicalName,
                    "&pagetype=entityrecord&id=",
                    entref.Id.ToString());
                if (!string.IsNullOrEmpty(url))
                {
                    Process.Start(url);
                }
            }
        }
    }
}