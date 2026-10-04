namespace DVLD_Presentation
{
    partial class AddEditUser
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
            this.Label = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.PersonInfo = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.ctrlPersonCard1 = new DVLD_Presentation.ctrlPersonCard();
            this.LoginInfo = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_UserID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chb_IsActive = new System.Windows.Forms.CheckBox();
            this.txb_ConfirmPass = new System.Windows.Forms.TextBox();
            this.txb_Pass = new System.Windows.Forms.TextBox();
            this.txb_UserName = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_AddNewPerson = new System.Windows.Forms.Button();
            this.bnt_Search = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.PersonInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(400, 9);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(162, 38);
            this.Label.TabIndex = 2;
            this.Label.Text = "Add User";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.PersonInfo);
            this.tabControl.Controls.Add(this.LoginInfo);
            this.tabControl.Location = new System.Drawing.Point(12, 87);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1146, 575);
            this.tabControl.TabIndex = 3;
            // 
            // PersonInfo
            // 
            this.PersonInfo.Controls.Add(this.btn_Next);
            this.PersonInfo.Controls.Add(this.groupBox1);
            this.PersonInfo.Controls.Add(this.ctrlPersonCard1);
            this.PersonInfo.Location = new System.Drawing.Point(4, 25);
            this.PersonInfo.Name = "PersonInfo";
            this.PersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.PersonInfo.Size = new System.Drawing.Size(1138, 546);
            this.PersonInfo.TabIndex = 0;
            this.PersonInfo.Text = "Person Information";
            this.PersonInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_AddNewPerson);
            this.groupBox1.Controls.Add(this.bnt_Search);
            this.groupBox1.Controls.Add(this.comboBox);
            this.groupBox1.Controls.Add(this.textBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1128, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Person";
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Person ID",
            "National Number"});
            this.comboBox.Location = new System.Drawing.Point(141, 43);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(201, 33);
            this.comboBox.TabIndex = 5;
            this.comboBox.TabStop = false;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(348, 46);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(226, 30);
            this.textBox.TabIndex = 1;
            this.textBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 112);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1128, 312);
            this.ctrlPersonCard1.TabIndex = 8;
            // 
            // LoginInfo
            // 
            this.LoginInfo.Controls.Add(this.label5);
            this.LoginInfo.Controls.Add(this.label4);
            this.LoginInfo.Controls.Add(this.label3);
            this.LoginInfo.Controls.Add(this.lb_UserID);
            this.LoginInfo.Controls.Add(this.label2);
            this.LoginInfo.Controls.Add(this.chb_IsActive);
            this.LoginInfo.Controls.Add(this.txb_ConfirmPass);
            this.LoginInfo.Controls.Add(this.txb_Pass);
            this.LoginInfo.Controls.Add(this.txb_UserName);
            this.LoginInfo.Controls.Add(this.btnSave);
            this.LoginInfo.Controls.Add(this.button1);
            this.LoginInfo.Location = new System.Drawing.Point(4, 25);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.LoginInfo.Size = new System.Drawing.Size(1138, 546);
            this.LoginInfo.TabIndex = 1;
            this.LoginInfo.Text = "Login Infomation";
            this.LoginInfo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Confirm Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(149, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "User Name :";
            // 
            // lb_UserID
            // 
            this.lb_UserID.AutoSize = true;
            this.lb_UserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_UserID.Location = new System.Drawing.Point(289, 78);
            this.lb_UserID.Name = "lb_UserID";
            this.lb_UserID.Size = new System.Drawing.Size(60, 25);
            this.lb_UserID.TabIndex = 14;
            this.lb_UserID.Text = "????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "User ID :";
            // 
            // chb_IsActive
            // 
            this.chb_IsActive.AutoSize = true;
            this.chb_IsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_IsActive.Location = new System.Drawing.Point(294, 304);
            this.chb_IsActive.Name = "chb_IsActive";
            this.chb_IsActive.Size = new System.Drawing.Size(108, 29);
            this.chb_IsActive.TabIndex = 3;
            this.chb_IsActive.Text = "Is Active";
            this.chb_IsActive.UseVisualStyleBackColor = true;
            // 
            // txb_ConfirmPass
            // 
            this.txb_ConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_ConfirmPass.Location = new System.Drawing.Point(294, 248);
            this.txb_ConfirmPass.Name = "txb_ConfirmPass";
            this.txb_ConfirmPass.Size = new System.Drawing.Size(213, 30);
            this.txb_ConfirmPass.TabIndex = 2;
            this.txb_ConfirmPass.UseSystemPasswordChar = true;
            this.txb_ConfirmPass.TextChanged += new System.EventHandler(this.txb_ConfirmPass_TextChanged);
            this.txb_ConfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.txb_ConfirmPass_Validating);
            // 
            // txb_Pass
            // 
            this.txb_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Pass.Location = new System.Drawing.Point(294, 192);
            this.txb_Pass.Name = "txb_Pass";
            this.txb_Pass.Size = new System.Drawing.Size(213, 30);
            this.txb_Pass.TabIndex = 1;
            this.txb_Pass.UseSystemPasswordChar = true;
            this.txb_Pass.Validating += new System.ComponentModel.CancelEventHandler(this.txb_Pass_Validating);
            // 
            // txb_UserName
            // 
            this.txb_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_UserName.Location = new System.Drawing.Point(294, 136);
            this.txb_UserName.Name = "txb_UserName";
            this.txb_UserName.Size = new System.Drawing.Size(213, 30);
            this.txb_UserName.TabIndex = 0;
            this.txb_UserName.Validating += new System.ComponentModel.CancelEventHandler(this.txb_UserName_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_Next
            // 
            this.btn_Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Next.Image = global::DVLD_Presentation.Properties.Resources.next;
            this.btn_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Next.Location = new System.Drawing.Point(994, 482);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Padding = new System.Windows.Forms.Padding(12);
            this.btn_Next.Size = new System.Drawing.Size(126, 49);
            this.btn_Next.TabIndex = 10;
            this.btn_Next.Text = "Next";
            this.btn_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_AddNewPerson
            // 
            this.btn_AddNewPerson.FlatAppearance.BorderSize = 0;
            this.btn_AddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddNewPerson.Image = global::DVLD_Presentation.Properties.Resources.new_person;
            this.btn_AddNewPerson.Location = new System.Drawing.Point(639, 49);
            this.btn_AddNewPerson.Name = "btn_AddNewPerson";
            this.btn_AddNewPerson.Size = new System.Drawing.Size(37, 30);
            this.btn_AddNewPerson.TabIndex = 7;
            this.btn_AddNewPerson.UseVisualStyleBackColor = true;
            this.btn_AddNewPerson.Click += new System.EventHandler(this.btn_AddNewPerson_Click);
            // 
            // bnt_Search
            // 
            this.bnt_Search.FlatAppearance.BorderSize = 0;
            this.bnt_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnt_Search.Image = global::DVLD_Presentation.Properties.Resources.search;
            this.bnt_Search.Location = new System.Drawing.Point(596, 46);
            this.bnt_Search.Name = "bnt_Search";
            this.bnt_Search.Size = new System.Drawing.Size(37, 30);
            this.bnt_Search.TabIndex = 6;
            this.bnt_Search.UseVisualStyleBackColor = true;
            this.bnt_Search.Click += new System.EventHandler(this.bnt_Search_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Image = global::DVLD_Presentation.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(969, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(12);
            this.btnSave.Size = new System.Drawing.Size(126, 49);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Image = global::DVLD_Presentation.Properties.Resources.back_button;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(837, 476);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(12);
            this.button1.Size = new System.Drawing.Size(126, 49);
            this.button1.TabIndex = 11;
            this.button1.Text = "Back";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 674);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditUser";
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.AddEditUser_Load);
            this.tabControl.ResumeLayout(false);
            this.PersonInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LoginInfo.ResumeLayout(false);
            this.LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage PersonInfo;
        private System.Windows.Forms.TabPage LoginInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox textBox;
        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.CheckBox chb_IsActive;
        private System.Windows.Forms.TextBox txb_ConfirmPass;
        private System.Windows.Forms.TextBox txb_Pass;
        private System.Windows.Forms.TextBox txb_UserName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_UserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button bnt_Search;
        private System.Windows.Forms.Button btn_AddNewPerson;
    }
}