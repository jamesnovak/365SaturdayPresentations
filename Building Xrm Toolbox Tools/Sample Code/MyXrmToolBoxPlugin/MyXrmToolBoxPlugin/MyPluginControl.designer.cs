namespace MyXrmToolBoxPlugin
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxSecurityRoles = new System.Windows.Forms.ListBox();
            this.crmGridView = new Cinteros.Xrm.CRMWinForm.CRMGridView();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crmGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1445, 39);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(171, 36);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(91, 36);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxSecurityRoles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crmGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1445, 998);
            this.splitContainer1.SplitterDistance = 480;
            this.splitContainer1.TabIndex = 6;
            // 
            // listBoxSecurityRoles
            // 
            this.listBoxSecurityRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSecurityRoles.FormattingEnabled = true;
            this.listBoxSecurityRoles.ItemHeight = 25;
            this.listBoxSecurityRoles.Location = new System.Drawing.Point(0, 0);
            this.listBoxSecurityRoles.Name = "listBoxSecurityRoles";
            this.listBoxSecurityRoles.Size = new System.Drawing.Size(480, 998);
            this.listBoxSecurityRoles.TabIndex = 6;
            this.listBoxSecurityRoles.SelectedIndexChanged += new System.EventHandler(this.listBoxSecurityRoles_SelectedIndexChanged);
            // 
            // crmGridView
            // 
            this.crmGridView.AllowUserToAddRows = false;
            this.crmGridView.AllowUserToDeleteRows = false;
            this.crmGridView.AllowUserToOrderColumns = true;
            this.crmGridView.AllowUserToResizeRows = false;
            this.crmGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crmGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crmGridView.EntityReferenceClickable = true;
            this.crmGridView.FilterColumns = "";
            this.crmGridView.Location = new System.Drawing.Point(0, 0);
            this.crmGridView.Name = "crmGridView";
            this.crmGridView.ReadOnly = true;
            this.crmGridView.RowTemplate.Height = 31;
            this.crmGridView.ShowIdColumn = false;
            this.crmGridView.Size = new System.Drawing.Size(961, 998);
            this.crmGridView.TabIndex = 0;
            this.crmGridView.RecordClick += new Cinteros.Xrm.CRMWinForm.CRMRecordEventHandler(this.crmGridView_RecordClick);
            this.crmGridView.RecordDoubleClick += new Cinteros.Xrm.CRMWinForm.CRMRecordEventHandler(this.crmGridView_RecordDoubleClick);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1445, 1037);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crmGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxSecurityRoles;
        private Cinteros.Xrm.CRMWinForm.CRMGridView crmGridView;
    }
}
