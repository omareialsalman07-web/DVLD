namespace DVLD_Presentation.UserControls
{
    partial class ctrlUserSelecter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_AddNewPerson = new System.Windows.Forms.Button();
            this.bnt_Search = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonCard1 = new DVLD_Presentation.ctrlPersonCard();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_AddNewPerson);
            this.groupBox1.Controls.Add(this.bnt_Search);
            this.groupBox1.Controls.Add(this.comboBox);
            this.groupBox1.Controls.Add(this.textBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1128, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Person";
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(0, 108);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1128, 312);
            this.ctrlPersonCard1.TabIndex = 10;
            // 
            // ctrlUserSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlUserSelecter";
            this.Size = new System.Drawing.Size(1130, 430);
            this.Load += new System.EventHandler(this.ctrlUserSelecter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_AddNewPerson;
        private System.Windows.Forms.Button bnt_Search;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox textBox;
        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
