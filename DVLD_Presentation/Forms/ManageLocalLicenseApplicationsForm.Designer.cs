namespace DVLD_Presentation.Forms
{
    partial class ManageLocalLicenseApplicationsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageLocalLicenseApplicationsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cms_ManageApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_AddApplication = new System.Windows.Forms.Button();
            this.showApplicationInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancleApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionStToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cms_ManageApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.cms_ManageApplication;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // cms_ManageApplication
            // 
            this.cms_ManageApplication.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_ManageApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationInfoToolStripMenuItem,
            this.cancleApplicationToolStripMenuItem,
            this.toolStripSeparator1,
            this.sToolStripMenuItem,
            this.issueLicenseFirstTimeToolStripMenuItem,
            this.showLiToolStripMenuItem});
            this.cms_ManageApplication.Name = "cms_ManageApplication";
            resources.ApplyResources(this.cms_ManageApplication, "cms_ManageApplication");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btn_refresh
            // 
            this.btn_refresh.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_refresh, "btn_refresh");
            this.btn_refresh.Image = global::DVLD_Presentation.Properties.Resources.refresh;
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_AddApplication
            // 
            this.btn_AddApplication.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_AddApplication, "btn_AddApplication");
            this.btn_AddApplication.Image = global::DVLD_Presentation.Properties.Resources.plus_small;
            this.btn_AddApplication.Name = "btn_AddApplication";
            this.btn_AddApplication.UseVisualStyleBackColor = true;
            this.btn_AddApplication.Click += new System.EventHandler(this.btn_AddApplication_Click);
            // 
            // showApplicationInfoToolStripMenuItem
            // 
            this.showApplicationInfoToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.applications;
            this.showApplicationInfoToolStripMenuItem.Name = "showApplicationInfoToolStripMenuItem";
            resources.ApplyResources(this.showApplicationInfoToolStripMenuItem, "showApplicationInfoToolStripMenuItem");
            this.showApplicationInfoToolStripMenuItem.Click += new System.EventHandler(this.showApplicationInfoToolStripMenuItem_Click);
            // 
            // cancleApplicationToolStripMenuItem
            // 
            this.cancleApplicationToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.cancle;
            this.cancleApplicationToolStripMenuItem.Name = "cancleApplicationToolStripMenuItem";
            resources.ApplyResources(this.cancleApplicationToolStripMenuItem, "cancleApplicationToolStripMenuItem");
            this.cancleApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancleApplicationToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionStToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.sToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.exam_time;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            resources.ApplyResources(this.sToolStripMenuItem, "sToolStripMenuItem");
            // 
            // visionStToolStripMenuItem
            // 
            this.visionStToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.eye_scan;
            this.visionStToolStripMenuItem.Name = "visionStToolStripMenuItem";
            resources.ApplyResources(this.visionStToolStripMenuItem, "visionStToolStripMenuItem");
            this.visionStToolStripMenuItem.Click += new System.EventHandler(this.visionStToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.content;
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            resources.ApplyResources(this.writtenTestToolStripMenuItem, "writtenTestToolStripMenuItem");
            this.writtenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.drivingTest;
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            resources.ApplyResources(this.streetTestToolStripMenuItem, "streetTestToolStripMenuItem");
            this.streetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // issueLicenseFirstTimeToolStripMenuItem
            // 
            this.issueLicenseFirstTimeToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.plus_small;
            this.issueLicenseFirstTimeToolStripMenuItem.Name = "issueLicenseFirstTimeToolStripMenuItem";
            resources.ApplyResources(this.issueLicenseFirstTimeToolStripMenuItem, "issueLicenseFirstTimeToolStripMenuItem");
            this.issueLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLiToolStripMenuItem
            // 
            this.showLiToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.Driving_License;
            this.showLiToolStripMenuItem.Name = "showLiToolStripMenuItem";
            resources.ApplyResources(this.showLiToolStripMenuItem, "showLiToolStripMenuItem");
            this.showLiToolStripMenuItem.Click += new System.EventHandler(this.showLiToolStripMenuItem_Click);
            // 
            // ManageLocalLicenseApplicationsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_AddApplication);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ManageLocalLicenseApplicationsForm";
            this.Load += new System.EventHandler(this.ManageLocalLicenseApplicationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cms_ManageApplication.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cms_ManageApplication;
        private System.Windows.Forms.ToolStripMenuItem cancleApplicationToolStripMenuItem;
        private System.Windows.Forms.Button btn_AddApplication;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionStToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showApplicationInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btn_refresh;
    }
}