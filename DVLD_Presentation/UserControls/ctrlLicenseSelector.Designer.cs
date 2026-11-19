namespace DVLD_Presentation.UserControls
{
    partial class ctrlLicenseSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txb_LicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlLocalLicenseInfo1 = new DVLD_Presentation.UserControls.ctrlLocalLicenseInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Local = new System.Windows.Forms.RadioButton();
            this.rb_International = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txb_LicenseID
            // 
            this.txb_LicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_LicenseID.Location = new System.Drawing.Point(315, 53);
            this.txb_LicenseID.Name = "txb_LicenseID";
            this.txb_LicenseID.Size = new System.Drawing.Size(219, 30);
            this.txb_LicenseID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Liicense ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.driver_license;
            this.pictureBox1.Location = new System.Drawing.Point(261, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::DVLD_Presentation.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(549, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 44);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlLocalLicenseInfo1
            // 
            this.ctrlLocalLicenseInfo1.Location = new System.Drawing.Point(3, 109);
            this.ctrlLocalLicenseInfo1.Name = "ctrlLocalLicenseInfo1";
            this.ctrlLocalLicenseInfo1.Size = new System.Drawing.Size(935, 341);
            this.ctrlLocalLicenseInfo1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_International);
            this.groupBox1.Controls.Add(this.rb_Local);
            this.groupBox1.Location = new System.Drawing.Point(617, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 76);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "License Type";
            // 
            // rb_Local
            // 
            this.rb_Local.AutoSize = true;
            this.rb_Local.Location = new System.Drawing.Point(32, 19);
            this.rb_Local.Name = "rb_Local";
            this.rb_Local.Size = new System.Drawing.Size(61, 20);
            this.rb_Local.TabIndex = 0;
            this.rb_Local.TabStop = true;
            this.rb_Local.Text = "Local";
            this.rb_Local.UseVisualStyleBackColor = true;
            // 
            // rb_International
            // 
            this.rb_International.AutoSize = true;
            this.rb_International.Location = new System.Drawing.Point(32, 50);
            this.rb_International.Name = "rb_International";
            this.rb_International.Size = new System.Drawing.Size(100, 20);
            this.rb_International.TabIndex = 1;
            this.rb_International.TabStop = true;
            this.rb_International.Text = "International";
            this.rb_International.UseVisualStyleBackColor = true;
            // 
            // ctrlLicenseSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_LicenseID);
            this.Controls.Add(this.ctrlLocalLicenseInfo1);
            this.Name = "ctrlLicenseSelector";
            this.Size = new System.Drawing.Size(944, 461);
            this.Load += new System.EventHandler(this.ctrlLocalLicenseSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLocalLicenseInfo ctrlLocalLicenseInfo1;
        private System.Windows.Forms.TextBox txb_LicenseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_International;
        private System.Windows.Forms.RadioButton rb_Local;
    }
}
