namespace DVLD_Presentation.Forms
{
    partial class ReplacementForLostorDamagedLicenseForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Damaged = new System.Windows.Forms.RadioButton();
            this.rb_Lost = new System.Windows.Forms.RadioButton();
            this.ctrlLicenseSelector1 = new DVLD_Presentation.UserControls.ctrlLicenseSelector();
            this.ctrlBasicApplicationInfo1 = new DVLD_Presentation.UserControls.ctrlBasicApplicationInfo();
            this.lknl_ShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lknl_ShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btn_Renew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Damaged);
            this.groupBox1.Controls.Add(this.rb_Lost);
            this.groupBox1.Location = new System.Drawing.Point(549, 800);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Type";
            // 
            // rb_Damaged
            // 
            this.rb_Damaged.AutoSize = true;
            this.rb_Damaged.Location = new System.Drawing.Point(103, 21);
            this.rb_Damaged.Name = "rb_Damaged";
            this.rb_Damaged.Size = new System.Drawing.Size(89, 20);
            this.rb_Damaged.TabIndex = 1;
            this.rb_Damaged.TabStop = true;
            this.rb_Damaged.Text = "Damaged";
            this.rb_Damaged.UseVisualStyleBackColor = true;
            // 
            // rb_Lost
            // 
            this.rb_Lost.AutoSize = true;
            this.rb_Lost.Location = new System.Drawing.Point(6, 22);
            this.rb_Lost.Name = "rb_Lost";
            this.rb_Lost.Size = new System.Drawing.Size(53, 20);
            this.rb_Lost.TabIndex = 0;
            this.rb_Lost.TabStop = true;
            this.rb_Lost.Text = "Lost";
            this.rb_Lost.UseVisualStyleBackColor = true;
            // 
            // ctrlLicenseSelector1
            // 
            this.ctrlLicenseSelector1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLicenseSelector1.Name = "ctrlLicenseSelector1";
            this.ctrlLicenseSelector1.Size = new System.Drawing.Size(962, 601);
            this.ctrlLicenseSelector1.TabIndex = 7;
            // 
            // ctrlBasicApplicationInfo1
            // 
            this.ctrlBasicApplicationInfo1.Location = new System.Drawing.Point(12, 624);
            this.ctrlBasicApplicationInfo1.Name = "ctrlBasicApplicationInfo1";
            this.ctrlBasicApplicationInfo1.Size = new System.Drawing.Size(1008, 175);
            this.ctrlBasicApplicationInfo1.TabIndex = 8;
            // 
            // lknl_ShowLicenseHistory
            // 
            this.lknl_ShowLicenseHistory.AutoSize = true;
            this.lknl_ShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lknl_ShowLicenseHistory.Location = new System.Drawing.Point(15, 816);
            this.lknl_ShowLicenseHistory.Name = "lknl_ShowLicenseHistory";
            this.lknl_ShowLicenseHistory.Size = new System.Drawing.Size(231, 25);
            this.lknl_ShowLicenseHistory.TabIndex = 11;
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
            this.lknl_ShowLicenseInfo.TabIndex = 10;
            this.lknl_ShowLicenseInfo.TabStop = true;
            this.lknl_ShowLicenseInfo.Text = "Show Licenses Info";
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
            this.btn_Renew.TabIndex = 9;
            this.btn_Renew.Text = "Replace";
            this.btn_Renew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Renew.UseVisualStyleBackColor = true;
            this.btn_Renew.Click += new System.EventHandler(this.btn_Renew_Click);
            // 
            // ReplacementForLostorDamagedLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 853);
            this.Controls.Add(this.lknl_ShowLicenseHistory);
            this.Controls.Add(this.lknl_ShowLicenseInfo);
            this.Controls.Add(this.btn_Renew);
            this.Controls.Add(this.ctrlBasicApplicationInfo1);
            this.Controls.Add(this.ctrlLicenseSelector1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplacementForLostorDamagedLicenseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacementg for Lost or Damaged License";
            this.Load += new System.EventHandler(this.ReplacementForLostorDamagedLicenseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Damaged;
        private System.Windows.Forms.RadioButton rb_Lost;
        private UserControls.ctrlLicenseSelector ctrlLicenseSelector1;
        private UserControls.ctrlBasicApplicationInfo ctrlBasicApplicationInfo1;
        private System.Windows.Forms.LinkLabel lknl_ShowLicenseHistory;
        private System.Windows.Forms.LinkLabel lknl_ShowLicenseInfo;
        private System.Windows.Forms.Button btn_Renew;
    }
}