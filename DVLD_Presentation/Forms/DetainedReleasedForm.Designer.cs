namespace DVLD_Presentation.Forms
{
    partial class DetainedReleasedForm
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
            this.lknl_ShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lknl_ShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrlBasicApplicationInfo1 = new DVLD_Presentation.UserControls.ctrlBasicApplicationInfo();
            this.ctrlLicenseSelector1 = new DVLD_Presentation.UserControls.ctrlLicenseSelector();
            this.btn_Detain_Release = new System.Windows.Forms.Button();
            this.mtxb_FineFees = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lknl_ShowLicenseHistory
            // 
            this.lknl_ShowLicenseHistory.AutoSize = true;
            this.lknl_ShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lknl_ShowLicenseHistory.Location = new System.Drawing.Point(15, 816);
            this.lknl_ShowLicenseHistory.Name = "lknl_ShowLicenseHistory";
            this.lknl_ShowLicenseHistory.Size = new System.Drawing.Size(231, 25);
            this.lknl_ShowLicenseHistory.TabIndex = 13;
            this.lknl_ShowLicenseHistory.TabStop = true;
            this.lknl_ShowLicenseHistory.Text = "Show Licenses History";
            this.lknl_ShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknl_ShowLicenseHistory_LinkClicked);
            // 
            // lknl_ShowLicenseInfo
            // 
            this.lknl_ShowLicenseInfo.AutoSize = true;
            this.lknl_ShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lknl_ShowLicenseInfo.Location = new System.Drawing.Point(252, 819);
            this.lknl_ShowLicenseInfo.Name = "lknl_ShowLicenseInfo";
            this.lknl_ShowLicenseInfo.Size = new System.Drawing.Size(200, 25);
            this.lknl_ShowLicenseInfo.TabIndex = 12;
            this.lknl_ShowLicenseInfo.TabStop = true;
            this.lknl_ShowLicenseInfo.Text = "Show Licenses Info";
            // 
            // ctrlBasicApplicationInfo1
            // 
            this.ctrlBasicApplicationInfo1.Location = new System.Drawing.Point(12, 619);
            this.ctrlBasicApplicationInfo1.Name = "ctrlBasicApplicationInfo1";
            this.ctrlBasicApplicationInfo1.Size = new System.Drawing.Size(1008, 175);
            this.ctrlBasicApplicationInfo1.TabIndex = 10;
            // 
            // ctrlLicenseSelector1
            // 
            this.ctrlLicenseSelector1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLicenseSelector1.Name = "ctrlLicenseSelector1";
            this.ctrlLicenseSelector1.Size = new System.Drawing.Size(962, 601);
            this.ctrlLicenseSelector1.TabIndex = 9;
            // 
            // btn_Detain_Release
            // 
            this.btn_Detain_Release.FlatAppearance.BorderSize = 0;
            this.btn_Detain_Release.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Detain_Release.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Detain_Release.Image = global::DVLD_Presentation.Properties.Resources.Release_Detained_License_32;
            this.btn_Detain_Release.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Detain_Release.Location = new System.Drawing.Point(838, 800);
            this.btn_Detain_Release.Name = "btn_Detain_Release";
            this.btn_Detain_Release.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btn_Detain_Release.Size = new System.Drawing.Size(182, 41);
            this.btn_Detain_Release.TabIndex = 11;
            this.btn_Detain_Release.Text = "Detain / Release";
            this.btn_Detain_Release.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detain_Release.UseVisualStyleBackColor = true;
            this.btn_Detain_Release.Click += new System.EventHandler(this.btn_Detain_Release_Click);
            // 
            // mtxb_FineFees
            // 
            this.mtxb_FineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxb_FineFees.Location = new System.Drawing.Point(162, 12);
            this.mtxb_FineFees.Mask = "00000";
            this.mtxb_FineFees.Name = "mtxb_FineFees";
            this.mtxb_FineFees.Size = new System.Drawing.Size(100, 27);
            this.mtxb_FineFees.TabIndex = 14;
            this.mtxb_FineFees.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Fine Fees:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.charge;
            this.pictureBox1.Location = new System.Drawing.Point(110, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mtxb_FineFees);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(535, 800);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 44);
            this.panel1.TabIndex = 17;
            // 
            // DetainedReleasedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 853);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lknl_ShowLicenseHistory);
            this.Controls.Add(this.lknl_ShowLicenseInfo);
            this.Controls.Add(this.btn_Detain_Release);
            this.Controls.Add(this.ctrlBasicApplicationInfo1);
            this.Controls.Add(this.ctrlLicenseSelector1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DetainedReleasedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detained Released Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetainedReleasedForm_FormClosed);
            this.Load += new System.EventHandler(this.DetainedReleasedForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lknl_ShowLicenseHistory;
        private System.Windows.Forms.LinkLabel lknl_ShowLicenseInfo;
        private System.Windows.Forms.Button btn_Detain_Release;
        private UserControls.ctrlBasicApplicationInfo ctrlBasicApplicationInfo1;
        private UserControls.ctrlLicenseSelector ctrlLicenseSelector1;
        private System.Windows.Forms.MaskedTextBox mtxb_FineFees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}