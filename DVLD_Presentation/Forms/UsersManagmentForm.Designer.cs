namespace DVLD_Presentation.Forms
{
    partial class UsersManagmentForm
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
            this.lst_Users = new System.Windows.Forms.ListView();
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PersonID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmUserManagement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePsswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sentEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pn_ApplyFilter = new System.Windows.Forms.Panel();
            this.chb_IsActive = new System.Windows.Forms.CheckBox();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.cmb_Filter = new System.Windows.Forms.ComboBox();
            this.cmUserManagement.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pn_ApplyFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_Users
            // 
            this.lst_Users.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.PersonID,
            this.FullName,
            this.UserName,
            this.IsActive});
            this.lst_Users.ContextMenuStrip = this.cmUserManagement;
            this.lst_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Users.FullRowSelect = true;
            this.lst_Users.HideSelection = false;
            this.lst_Users.Location = new System.Drawing.Point(10, 168);
            this.lst_Users.Name = "lst_Users";
            this.lst_Users.Size = new System.Drawing.Size(1077, 419);
            this.lst_Users.TabIndex = 0;
            this.lst_Users.UseCompatibleStateImageBehavior = false;
            this.lst_Users.View = System.Windows.Forms.View.Details;
            // 
            // UserID
            // 
            this.UserID.Text = "User ID";
            this.UserID.Width = 84;
            // 
            // PersonID
            // 
            this.PersonID.Text = "Person ID";
            this.PersonID.Width = 112;
            // 
            // FullName
            // 
            this.FullName.Text = "FullName";
            this.FullName.Width = 296;
            // 
            // UserName
            // 
            this.UserName.Text = "User Name";
            this.UserName.Width = 215;
            // 
            // IsActive
            // 
            this.IsActive.Text = "Is Active";
            this.IsActive.Width = 108;
            // 
            // cmUserManagement
            // 
            this.cmUserManagement.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.cmUserManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.editUserToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.changePsswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.phoneCallToolStripMenuItem,
            this.sentEmailToolStripMenuItem});
            this.cmUserManagement.Name = "cmUserManagement";
            this.cmUserManagement.Size = new System.Drawing.Size(206, 304);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.applications;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(205, 42);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::DVLD_Presentation.Properties.Resources.user;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 42);
            this.toolStripMenuItem2.Text = "Add New";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.edit;
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(205, 42);
            this.editUserToolStripMenuItem.Text = "Edit";
            this.editUserToolStripMenuItem.Click += new System.EventHandler(this.editUserToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(205, 42);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // changePsswordToolStripMenuItem
            // 
            this.changePsswordToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.changePassword;
            this.changePsswordToolStripMenuItem.Name = "changePsswordToolStripMenuItem";
            this.changePsswordToolStripMenuItem.Size = new System.Drawing.Size(205, 42);
            this.changePsswordToolStripMenuItem.Text = "Change Pssword";
            this.changePsswordToolStripMenuItem.Click += new System.EventHandler(this.changePsswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.mobile;
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(205, 42);
            this.phoneCallToolStripMenuItem.Text = "Phone Call";
            // 
            // sentEmailToolStripMenuItem
            // 
            this.sentEmailToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.mail;
            this.sentEmailToolStripMenuItem.Name = "sentEmailToolStripMenuItem";
            this.sentEmailToolStripMenuItem.Size = new System.Drawing.Size(205, 42);
            this.sentEmailToolStripMenuItem.Text = "Sent Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(333, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users Management";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pn_ApplyFilter);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btn_AddUser);
            this.panel1.Controls.Add(this.cmb_Filter);
            this.panel1.Location = new System.Drawing.Point(10, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 100);
            this.panel1.TabIndex = 2;
            // 
            // pn_ApplyFilter
            // 
            this.pn_ApplyFilter.Controls.Add(this.chb_IsActive);
            this.pn_ApplyFilter.Controls.Add(this.maskedTextBox);
            this.pn_ApplyFilter.Location = new System.Drawing.Point(216, 28);
            this.pn_ApplyFilter.Name = "pn_ApplyFilter";
            this.pn_ApplyFilter.Size = new System.Drawing.Size(231, 47);
            this.pn_ApplyFilter.TabIndex = 5;
            // 
            // chb_IsActive
            // 
            this.chb_IsActive.AutoSize = true;
            this.chb_IsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_IsActive.Location = new System.Drawing.Point(16, 13);
            this.chb_IsActive.Name = "chb_IsActive";
            this.chb_IsActive.Size = new System.Drawing.Size(95, 24);
            this.chb_IsActive.TabIndex = 4;
            this.chb_IsActive.Text = "Is Active";
            this.chb_IsActive.UseVisualStyleBackColor = true;
            this.chb_IsActive.CheckedChanged += new System.EventHandler(this.chb_IsActive_CheckedChanged);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox.Location = new System.Drawing.Point(6, 10);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(222, 30);
            this.maskedTextBox.TabIndex = 1;
            this.maskedTextBox.TextChanged += new System.EventHandler(this.maskedTextBox_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::DVLD_Presentation.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(905, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 50);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.BackgroundImage = global::DVLD_Presentation.Properties.Resources.user;
            this.btn_AddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AddUser.FlatAppearance.BorderSize = 0;
            this.btn_AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddUser.Location = new System.Drawing.Point(986, 28);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(75, 50);
            this.btn_AddUser.TabIndex = 2;
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // cmb_Filter
            // 
            this.cmb_Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Filter.FormattingEnabled = true;
            this.cmb_Filter.Items.AddRange(new object[] {
            "None",
            "UserID",
            "PersonID",
            "FullName",
            "UserName",
            "IsActive"});
            this.cmb_Filter.Location = new System.Drawing.Point(18, 34);
            this.cmb_Filter.Name = "cmb_Filter";
            this.cmb_Filter.Size = new System.Drawing.Size(183, 33);
            this.cmb_Filter.TabIndex = 0;
            this.cmb_Filter.SelectedIndexChanged += new System.EventHandler(this.cmb_Filter_SelectedIndexChanged);
            // 
            // UsersManagmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_Users);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UsersManagmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users Managment";
            this.Load += new System.EventHandler(this.UsersManagmentForm_Load);
            this.cmUserManagement.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pn_ApplyFilter.ResumeLayout(false);
            this.pn_ApplyFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lst_Users;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader PersonID;
        private System.Windows.Forms.ColumnHeader FullName;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader IsActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.ComboBox cmb_Filter;
        private System.Windows.Forms.Panel pn_ApplyFilter;
        private System.Windows.Forms.CheckBox chb_IsActive;
        private System.Windows.Forms.ContextMenuStrip cmUserManagement;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePsswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sentEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}