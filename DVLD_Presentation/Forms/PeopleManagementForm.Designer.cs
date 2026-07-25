namespace DVLD_Presentation.Forms
{
    partial class PeopleManagementForm
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
            this.lstPeople = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NationalNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SeconedName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThirdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gendor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfBirth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nationality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecoreds = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstPeople
            // 
            this.lstPeople.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.NationalNo,
            this.FirstName,
            this.SeconedName,
            this.ThirdName,
            this.LastName,
            this.Gendor,
            this.DateOfBirth,
            this.Nationality,
            this.Phone,
            this.Email});
            this.lstPeople.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPeople.FullRowSelect = true;
            this.lstPeople.HideSelection = false;
            this.lstPeople.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstPeople.Location = new System.Drawing.Point(12, 182);
            this.lstPeople.Name = "lstPeople";
            this.lstPeople.Size = new System.Drawing.Size(1225, 408);
            this.lstPeople.TabIndex = 0;
            this.lstPeople.UseCompatibleStateImageBehavior = false;
            this.lstPeople.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // NationalNo
            // 
            this.NationalNo.Text = "National No";
            this.NationalNo.Width = 85;
            // 
            // FirstName
            // 
            this.FirstName.Text = "First Name";
            this.FirstName.Width = 90;
            // 
            // LastName
            // 
            this.LastName.Text = "Last Name";
            this.LastName.Width = 101;
            // 
            // SeconedName
            // 
            this.SeconedName.Text = "Seconed Name";
            this.SeconedName.Width = 111;
            // 
            // ThirdName
            // 
            this.ThirdName.Text = "Third Name";
            this.ThirdName.Width = 108;
            // 
            // Gendor
            // 
            this.Gendor.Text = "Gendor";
            this.Gendor.Width = 82;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.Text = "Date of Birth";
            this.DateOfBirth.Width = 128;
            // 
            // Nationality
            // 
            this.Nationality.Text = "Nationality";
            this.Nationality.Width = 0;
            // 
            // Phone
            // 
            this.Phone.Text = "Phone";
            this.Phone.Width = 125;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 551;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(421, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "People Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 607);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "# Recoreds : ";
            // 
            // lbRecoreds
            // 
            this.lbRecoreds.AutoSize = true;
            this.lbRecoreds.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecoreds.Location = new System.Drawing.Point(164, 607);
            this.lbRecoreds.Name = "lbRecoreds";
            this.lbRecoreds.Size = new System.Drawing.Size(48, 26);
            this.lbRecoreds.TabIndex = 6;
            this.lbRecoreds.Text = "????";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Presentation.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1115, 596);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 34);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::DVLD_Presentation.Properties.Resources.user;
            this.button1.Location = new System.Drawing.Point(1172, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 65);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::DVLD_Presentation.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(1101, 111);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 65);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Presentation.Properties.Resources.management;
            this.pictureBox1.Location = new System.Drawing.Point(475, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PeopleManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 635);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecoreds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPeople);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PeopleManagementForm";
            this.Text = "PeopleManagementForm";
            this.Load += new System.EventHandler(this.PeopleManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstPeople;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader NationalNo;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader SeconedName;
        private System.Windows.Forms.ColumnHeader ThirdName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.ColumnHeader Gendor;
        private System.Windows.Forms.ColumnHeader DateOfBirth;
        private System.Windows.Forms.ColumnHeader Nationality;
        private System.Windows.Forms.ColumnHeader Phone;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecoreds;
        private System.Windows.Forms.Button btnClose;
    }
}