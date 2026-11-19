namespace DVLD_Presentation.Forms
{
    partial class LicensesHistoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_LocalLicenses = new System.Windows.Forms.TabPage();
            this.dataGridView_Local = new System.Windows.Forms.DataGridView();
            this.tp_InternationalLicenses = new System.Windows.Forms.TabPage();
            this.dataGridView_International = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlDriverInfo1 = new DVLD_Presentation.UserControls.ctrlDriverInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tp_LocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Local)).BeginInit();
            this.tp_InternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_International)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(344, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "License History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(573, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_LocalLicenses);
            this.tabControl1.Controls.Add(this.tp_InternationalLicenses);
            this.tabControl1.Location = new System.Drawing.Point(6, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 228);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_LocalLicenses
            // 
            this.tp_LocalLicenses.Controls.Add(this.dataGridView_Local);
            this.tp_LocalLicenses.Location = new System.Drawing.Point(4, 25);
            this.tp_LocalLicenses.Name = "tp_LocalLicenses";
            this.tp_LocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tp_LocalLicenses.Size = new System.Drawing.Size(1113, 199);
            this.tp_LocalLicenses.TabIndex = 0;
            this.tp_LocalLicenses.Text = "Local";
            this.tp_LocalLicenses.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Local
            // 
            this.dataGridView_Local.AllowUserToAddRows = false;
            this.dataGridView_Local.AllowUserToDeleteRows = false;
            this.dataGridView_Local.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Local.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Local.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_Local.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Local.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView_Local.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_Local.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_Local.MultiSelect = false;
            this.dataGridView_Local.Name = "dataGridView_Local";
            this.dataGridView_Local.ReadOnly = true;
            this.dataGridView_Local.RowHeadersWidth = 51;
            this.dataGridView_Local.RowTemplate.Height = 24;
            this.dataGridView_Local.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Local.Size = new System.Drawing.Size(1101, 187);
            this.dataGridView_Local.TabIndex = 3;
            // 
            // tp_InternationalLicenses
            // 
            this.tp_InternationalLicenses.Controls.Add(this.dataGridView_International);
            this.tp_InternationalLicenses.Location = new System.Drawing.Point(4, 25);
            this.tp_InternationalLicenses.Name = "tp_InternationalLicenses";
            this.tp_InternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tp_InternationalLicenses.Size = new System.Drawing.Size(1113, 199);
            this.tp_InternationalLicenses.TabIndex = 1;
            this.tp_InternationalLicenses.Text = "International";
            this.tp_InternationalLicenses.UseVisualStyleBackColor = true;
            // 
            // dataGridView_International
            // 
            this.dataGridView_International.AllowUserToAddRows = false;
            this.dataGridView_International.AllowUserToDeleteRows = false;
            this.dataGridView_International.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_International.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_International.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_International.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_International.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView_International.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_International.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_International.MultiSelect = false;
            this.dataGridView_International.Name = "dataGridView_International";
            this.dataGridView_International.ReadOnly = true;
            this.dataGridView_International.RowHeadersWidth = 51;
            this.dataGridView_International.RowTemplate.Height = 24;
            this.dataGridView_International.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_International.Size = new System.Drawing.Size(1101, 187);
            this.dataGridView_International.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 606);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 255);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(201, 30);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.driver_license;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // ctrlDriverInfo1
            // 
            this.ctrlDriverInfo1.Location = new System.Drawing.Point(6, 132);
            this.ctrlDriverInfo1.Name = "ctrlDriverInfo1";
            this.ctrlDriverInfo1.Size = new System.Drawing.Size(1139, 468);
            this.ctrlDriverInfo1.TabIndex = 5;
            // 
            // LicensesHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 867);
            this.Controls.Add(this.ctrlDriverInfo1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LicensesHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licenses History";
            this.Load += new System.EventHandler(this.LicensesHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tp_LocalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Local)).EndInit();
            this.tp_InternationalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_International)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_LocalLicenses;
        private System.Windows.Forms.DataGridView dataGridView_Local;
        private System.Windows.Forms.TabPage tp_InternationalLicenses;
        private System.Windows.Forms.DataGridView dataGridView_International;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ctrlDriverInfo ctrlDriverInfo1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}