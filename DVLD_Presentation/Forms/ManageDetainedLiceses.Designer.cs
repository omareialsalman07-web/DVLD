namespace DVLD_Presentation.Forms
{
    partial class ManageDetainedLiceses
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDriverInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicesneHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Detain = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(12, 214);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1352, 507);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDriverInfoToolStripMenuItem,
            this.showLicesneHistoryToolStripMenuItem,
            this.releaseLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(222, 82);
            // 
            // showDriverInfoToolStripMenuItem
            // 
            this.showDriverInfoToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.driver;
            this.showDriverInfoToolStripMenuItem.Name = "showDriverInfoToolStripMenuItem";
            this.showDriverInfoToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.showDriverInfoToolStripMenuItem.Text = "Show Driver Info";
            this.showDriverInfoToolStripMenuItem.Click += new System.EventHandler(this.showDriverInfoToolStripMenuItem_Click);
            // 
            // showLicesneHistoryToolStripMenuItem
            // 
            this.showLicesneHistoryToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.history;
            this.showLicesneHistoryToolStripMenuItem.Name = "showLicesneHistoryToolStripMenuItem";
            this.showLicesneHistoryToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.showLicesneHistoryToolStripMenuItem.Text = "Show Licesne History";
            this.showLicesneHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicesneHistoryToolStripMenuItem_Click);
            // 
            // releaseLicenseToolStripMenuItem
            // 
            this.releaseLicenseToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.Release_Detained_License_32;
            this.releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            this.releaseLicenseToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.releaseLicenseToolStripMenuItem.Text = "Release License";
            this.releaseLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseLicenseToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(388, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Manage Detained Licenses";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.Detain_64;
            this.pictureBox1.Location = new System.Drawing.Point(475, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Detain
            // 
            this.btn_Detain.FlatAppearance.BorderSize = 0;
            this.btn_Detain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Detain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Detain.Image = global::DVLD_Presentation.Properties.Resources.Detain_64;
            this.btn_Detain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Detain.Location = new System.Drawing.Point(1196, 126);
            this.btn_Detain.Name = "btn_Detain";
            this.btn_Detain.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btn_Detain.Size = new System.Drawing.Size(168, 64);
            this.btn_Detain.TabIndex = 6;
            this.btn_Detain.Text = "Detain";
            this.btn_Detain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detain.UseVisualStyleBackColor = true;
            this.btn_Detain.Click += new System.EventHandler(this.btnDetained);
            // 
            // btnRelease
            // 
            this.btnRelease.FlatAppearance.BorderSize = 0;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Image = global::DVLD_Presentation.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(1010, 126);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(168, 64);
            this.btnRelease.TabIndex = 7;
            this.btnRelease.Text = "Release";
            this.btnRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btn_Release);
            // 
            // ManageDetainedLiceses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 733);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btn_Detain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ManageDetainedLiceses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Liceses";
            this.Load += new System.EventHandler(this.ManageDetainedLiceses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Detain;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDriverInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicesneHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseLicenseToolStripMenuItem;
    }
}