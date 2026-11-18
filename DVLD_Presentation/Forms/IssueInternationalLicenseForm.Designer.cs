namespace DVLD_Presentation.Forms
{
    partial class IssueInternationalLicenseForm
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
            this.ctrlBasicApplicationInfo1 = new DVLD_Presentation.UserControls.ctrlBasicApplicationInfo();
            this.ctrlLocalLicenseSelector1 = new DVLD_Presentation.UserControls.ctrlLocalLicenseSelector();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.lknl_ShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lknl_ShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ctrlBasicApplicationInfo1
            // 
            this.ctrlBasicApplicationInfo1.Location = new System.Drawing.Point(12, 479);
            this.ctrlBasicApplicationInfo1.Name = "ctrlBasicApplicationInfo1";
            this.ctrlBasicApplicationInfo1.Size = new System.Drawing.Size(1008, 294);
            this.ctrlBasicApplicationInfo1.TabIndex = 0;
            // 
            // ctrlLocalLicenseSelector1
            // 
            this.ctrlLocalLicenseSelector1.Location = new System.Drawing.Point(50, 12);
            this.ctrlLocalLicenseSelector1.Name = "ctrlLocalLicenseSelector1";
            this.ctrlLocalLicenseSelector1.Size = new System.Drawing.Size(944, 461);
            this.ctrlLocalLicenseSelector1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnIssue
            // 
            this.btnIssue.FlatAppearance.BorderSize = 0;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLD_Presentation.Properties.Resources.globe_50;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(826, 783);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnIssue.Size = new System.Drawing.Size(168, 63);
            this.btnIssue.TabIndex = 3;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // lknl_ShowLicenseInfo
            // 
            this.lknl_ShowLicenseInfo.AutoSize = true;
            this.lknl_ShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lknl_ShowLicenseInfo.Location = new System.Drawing.Point(309, 802);
            this.lknl_ShowLicenseInfo.Name = "lknl_ShowLicenseInfo";
            this.lknl_ShowLicenseInfo.Size = new System.Drawing.Size(200, 25);
            this.lknl_ShowLicenseInfo.TabIndex = 4;
            this.lknl_ShowLicenseInfo.TabStop = true;
            this.lknl_ShowLicenseInfo.Text = "Show Licenses Info";
            // 
            // lknl_ShowLicenseHistory
            // 
            this.lknl_ShowLicenseHistory.AutoSize = true;
            this.lknl_ShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lknl_ShowLicenseHistory.Location = new System.Drawing.Point(45, 802);
            this.lknl_ShowLicenseHistory.Name = "lknl_ShowLicenseHistory";
            this.lknl_ShowLicenseHistory.Size = new System.Drawing.Size(231, 25);
            this.lknl_ShowLicenseHistory.TabIndex = 5;
            this.lknl_ShowLicenseHistory.TabStop = true;
            this.lknl_ShowLicenseHistory.Text = "Show Licenses History";
            this.lknl_ShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknl_ShowLicenseHistory_LinkClicked);
            // 
            // IssueInternationalLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 858);
            this.Controls.Add(this.lknl_ShowLicenseHistory);
            this.Controls.Add(this.lknl_ShowLicenseInfo);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlLocalLicenseSelector1);
            this.Controls.Add(this.ctrlBasicApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IssueInternationalLicenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue International License";
            this.Load += new System.EventHandler(this.IssueInternationalLicenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlBasicApplicationInfo ctrlBasicApplicationInfo1;
        private UserControls.ctrlLocalLicenseSelector ctrlLocalLicenseSelector1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.LinkLabel lknl_ShowLicenseInfo;
        private System.Windows.Forms.LinkLabel lknl_ShowLicenseHistory;
    }
}