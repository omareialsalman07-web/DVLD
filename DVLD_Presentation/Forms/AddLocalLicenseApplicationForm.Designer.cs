namespace DVLD_Presentation.Forms
{
    partial class AddLocalLicenseApplicationForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_Person = new System.Windows.Forms.TabPage();
            this.tp_Application = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_ApplicationDate = new System.Windows.Forms.Label();
            this.lb_Fees = new System.Windows.Forms.Label();
            this.lb_CreatedBy = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.ctrlPersonSelecter1 = new DVLD_Presentation.UserControls.ctrlPersonSelecter();
            this.tabControl1.SuspendLayout();
            this.tp_Person.SuspendLayout();
            this.tp_Application.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_Person);
            this.tabControl1.Controls.Add(this.tp_Application);
            this.tabControl1.Location = new System.Drawing.Point(4, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1141, 502);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_Person
            // 
            this.tp_Person.Controls.Add(this.ctrlPersonSelecter1);
            this.tp_Person.Location = new System.Drawing.Point(4, 25);
            this.tp_Person.Name = "tp_Person";
            this.tp_Person.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Person.Size = new System.Drawing.Size(1133, 473);
            this.tp_Person.TabIndex = 0;
            this.tp_Person.Text = "Person";
            this.tp_Person.UseVisualStyleBackColor = true;
            // 
            // tp_Application
            // 
            this.tp_Application.Controls.Add(this.btn_Save);
            this.tp_Application.Controls.Add(this.cbLicenseClasses);
            this.tp_Application.Controls.Add(this.pictureBox5);
            this.tp_Application.Controls.Add(this.pictureBox4);
            this.tp_Application.Controls.Add(this.pictureBox3);
            this.tp_Application.Controls.Add(this.pictureBox2);
            this.tp_Application.Controls.Add(this.lb_CreatedBy);
            this.tp_Application.Controls.Add(this.lb_Fees);
            this.tp_Application.Controls.Add(this.lb_ApplicationDate);
            this.tp_Application.Controls.Add(this.label6);
            this.tp_Application.Controls.Add(this.label5);
            this.tp_Application.Controls.Add(this.label4);
            this.tp_Application.Controls.Add(this.label3);
            this.tp_Application.Location = new System.Drawing.Point(4, 25);
            this.tp_Application.Name = "tp_Application";
            this.tp_Application.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Application.Size = new System.Drawing.Size(1133, 473);
            this.tp_Application.TabIndex = 1;
            this.tp_Application.Text = "Application";
            this.tp_Application.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(305, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 29);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(238, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(271, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(236, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Appllication Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(392, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Local License Application";
            // 
            // lb_ApplicationDate
            // 
            this.lb_ApplicationDate.AutoSize = true;
            this.lb_ApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ApplicationDate.Location = new System.Drawing.Point(532, 143);
            this.lb_ApplicationDate.Name = "lb_ApplicationDate";
            this.lb_ApplicationDate.Size = new System.Drawing.Size(65, 29);
            this.lb_ApplicationDate.TabIndex = 6;
            this.lb_ApplicationDate.Text = "????";
            // 
            // lb_Fees
            // 
            this.lb_Fees.AutoSize = true;
            this.lb_Fees.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Fees.Location = new System.Drawing.Point(532, 267);
            this.lb_Fees.Name = "lb_Fees";
            this.lb_Fees.Size = new System.Drawing.Size(65, 29);
            this.lb_Fees.TabIndex = 7;
            this.lb_Fees.Text = "????";
            // 
            // lb_CreatedBy
            // 
            this.lb_CreatedBy.AutoSize = true;
            this.lb_CreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_CreatedBy.Location = new System.Drawing.Point(532, 329);
            this.lb_CreatedBy.Name = "lb_CreatedBy";
            this.lb_CreatedBy.Size = new System.Drawing.Size(65, 29);
            this.lb_CreatedBy.TabIndex = 8;
            this.lb_CreatedBy.Text = "????";
            // 
            // btn_Back
            // 
            this.btn_Back.Image = global::DVLD_Presentation.Properties.Resources.back_button;
            this.btn_Back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Back.Location = new System.Drawing.Point(882, 600);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btn_Back.Size = new System.Drawing.Size(125, 46);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "Back";
            this.btn_Back.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::DVLD_Presentation.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(1013, 600);
            this.btnNext.Name = "btnNext";
            this.btnNext.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnNext.Size = new System.Drawing.Size(125, 46);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Presentation.Properties.Resources.name;
            this.pictureBox5.Location = new System.Drawing.Point(460, 330);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Presentation.Properties.Resources.charge;
            this.pictureBox4.Location = new System.Drawing.Point(460, 268);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Presentation.Properties.Resources.driver_license;
            this.pictureBox3.Location = new System.Drawing.Point(460, 205);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Presentation.Properties.Resources.age;
            this.pictureBox2.Location = new System.Drawing.Point(460, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 28);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(537, 208);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(267, 28);
            this.cbLicenseClasses.TabIndex = 14;
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::DVLD_Presentation.Properties.Resources.save;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.Location = new System.Drawing.Point(992, 412);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btn_Save.Size = new System.Drawing.Size(125, 46);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ctrlPersonSelecter1
            // 
            this.ctrlPersonSelecter1.Location = new System.Drawing.Point(0, 6);
            this.ctrlPersonSelecter1.Name = "ctrlPersonSelecter1";
            this.ctrlPersonSelecter1.Size = new System.Drawing.Size(1130, 430);
            this.ctrlPersonSelecter1.TabIndex = 1;
            // 
            // AddLocalLicenseApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 658);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddLocalLicenseApplicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddLocalLicenseApplicationForm";
            this.Load += new System.EventHandler(this.AddLocalLicenseApplicationForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tp_Person.ResumeLayout(false);
            this.tp_Application.ResumeLayout(false);
            this.tp_Application.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_Person;
        private System.Windows.Forms.TabPage tp_Application;
        private UserControls.ctrlPersonSelecter ctrlPersonSelecter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_CreatedBy;
        private System.Windows.Forms.Label lb_Fees;
        private System.Windows.Forms.Label lb_ApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Button btn_Save;
    }
}