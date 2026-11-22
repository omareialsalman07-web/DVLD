namespace DVLD_Presentation.Forms
{
    partial class RenewLicenseForm
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
            this.ctrlLicenseSelector1 = new DVLD_Presentation.UserControls.ctrlLicenseSelector();
            this.ctrlBasicApplicationInfo1 = new DVLD_Presentation.UserControls.ctrlBasicApplicationInfo();
            this.lknl_ShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lknl_ShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btn_Renew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLicenseSelector1
            // 
            this.ctrlLicenseSelector1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLicenseSelector1.Name = "ctrlLicenseSelector1";
            this.ctrlLicenseSelector1.Size = new System.Drawing.Size(962, 601);
            this.ctrlLicenseSelector1.TabIndex = 0;
            // 
            // ctrlBasicApplicationInfo1
            // 
            this.ctrlBasicApplicationInfo1.Location = new System.Drawing.Point(12, 619);
            this.ctrlBasicApplicationInfo1.Name = "ctrlBasicApplicationInfo1";
            this.ctrlBasicApplicationInfo1.Size = new System.Drawing.Size(1008, 175);
            this.ctrlBasicApplicationInfo1.TabIndex = 1;
            // 
            // lknl_ShowLicenseHistory
            // 
            this.lknl_ShowLicenseHistory.AutoSize = true;
            this.lknl_ShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lknl_ShowLicenseHistory.Location = new System.Drawing.Point(15, 816);
            this.lknl_ShowLicenseHistory.Name = "lknl_ShowLicenseHistory";
            this.lknl_ShowLicenseHistory.Size = new System.Drawing.Size(231, 25);
            this.lknl_ShowLicenseHistory.TabIndex = 8;
            this.lknl_ShowLicenseHistory.TabStop = true;
            this.lknl_ShowLicenseHistory.Text = "Show Licenses History";
            this.lknl_ShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknl_ShowLicenseHistory_LinkClicked);
            // 
            // lknl_ShowLicenseInfo
            // 
            this.lknl_ShowLicenseInfo.AutoSize = true;
            this.lknl_ShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lknl_ShowLicenseInfo.Location = new System.Drawing.Point(279, 816);
            this.lknl_ShowLicenseInfo.Name = "lknl_ShowLicenseInfo";
            this.lknl_ShowLicenseInfo.Size = new System.Drawing.Size(200, 25);
            this.lknl_ShowLicenseInfo.TabIndex = 7;
            this.lknl_ShowLicenseInfo.TabStop = true;
            this.lknl_ShowLicenseInfo.Text = "Show Licenses Info";
            this.lknl_ShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknl_ShowLicenseInfo_LinkClicked);
            // 
            // btn_Renew
            // 
            this.btn_Renew.FlatAppearance.BorderSize = 0;
            this.btn_Renew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Renew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Renew.Image = global::DVLD_Presentation.Properties.Resources.Renew_Driving_License_32;
            this.btn_Renew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Renew.Location = new System.Drawing.Point(838, 800);
            this.btn_Renew.Name = "btn_Renew";
            this.btn_Renew.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btn_Renew.Size = new System.Drawing.Size(182, 41);
            this.btn_Renew.TabIndex = 6;
            this.btn_Renew.Text = "Renew";
            this.btn_Renew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Renew.UseVisualStyleBackColor = true;
            this.btn_Renew.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // RenewLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 853);
            this.Controls.Add(this.lknl_ShowLicenseHistory);
            this.Controls.Add(this.lknl_ShowLicenseInfo);
            this.Controls.Add(this.btn_Renew);
            this.Controls.Add(this.ctrlBasicApplicationInfo1);
            this.Controls.Add(this.ctrlLicenseSelector1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RenewLicenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew License";
            this.Load += new System.EventHandler(this.RenewLicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlLicenseSelector ctrlLicenseSelector1;
        private UserControls.ctrlBasicApplicationInfo ctrlBasicApplicationInfo1;
        private System.Windows.Forms.LinkLabel lknl_ShowLicenseHistory;
        private System.Windows.Forms.LinkLabel lknl_ShowLicenseInfo;
        private System.Windows.Forms.Button btn_Renew;
    }
}