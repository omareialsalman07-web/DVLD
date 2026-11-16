namespace DVLD_Presentation.Forms
{
    partial class IssueLocalLicenceForm
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
            this.ctrlLocalLicenseApplicationInfo1 = new DVLD_Presentation.UserControls.ctrlLocalLicenseApplicationInfo();
            this.btnIssue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLocalLicenseApplicationInfo1
            // 
            this.ctrlLocalLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLocalLicenseApplicationInfo1.Name = "ctrlLocalLicenseApplicationInfo1";
            this.ctrlLocalLicenseApplicationInfo1.Size = new System.Drawing.Size(1020, 483);
            this.ctrlLocalLicenseApplicationInfo1.TabIndex = 0;
            // 
            // btnIssue
            // 
            this.btnIssue.FlatAppearance.BorderSize = 0;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLD_Presentation.Properties.Resources.plus_small;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(422, 501);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnIssue.Size = new System.Drawing.Size(206, 71);
            this.btnIssue.TabIndex = 1;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // IssueLocalLicenceForm
            // 
            this.AcceptButton = this.btnIssue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 580);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrlLocalLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IssueLocalLicenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Local Licence Form";
            this.Load += new System.EventHandler(this.IssueLocalLicenceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ctrlLocalLicenseApplicationInfo ctrlLocalLicenseApplicationInfo1;
        private System.Windows.Forms.Button btnIssue;
    }
}