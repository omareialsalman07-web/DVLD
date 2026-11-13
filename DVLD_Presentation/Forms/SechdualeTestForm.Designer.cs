namespace DVLD_Presentation.Forms
{
    partial class SechdualeTestForm
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.pbFromImage = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancleAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddAppointments = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ctrlLocalLicenseApplicationInfo1 = new DVLD_Presentation.UserControls.ctrlLocalLicenseApplicationInfo();
            this.lbPassedMessage = new System.Windows.Forms.Label();
            this.lbTrails = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFromImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(12, 33);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(169, 38);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "????????";
            // 
            // pbFromImage
            // 
            this.pbFromImage.Location = new System.Drawing.Point(914, 12);
            this.pbFromImage.Name = "pbFromImage";
            this.pbFromImage.Size = new System.Drawing.Size(100, 87);
            this.pbFromImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFromImage.TabIndex = 2;
            this.pbFromImage.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(12, 656);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1013, 197);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeTestToolStripMenuItem,
            this.takeTestToolStripMenuItem1,
            this.cancleAppointmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(219, 110);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.edit;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.takeTestToolStripMenuItem.Text = "Edit Tets";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.EditTestToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem1
            // 
            this.takeTestToolStripMenuItem1.Image = global::DVLD_Presentation.Properties.Resources.exam_time;
            this.takeTestToolStripMenuItem1.Name = "takeTestToolStripMenuItem1";
            this.takeTestToolStripMenuItem1.Size = new System.Drawing.Size(218, 26);
            this.takeTestToolStripMenuItem1.Text = "Take Test";
            this.takeTestToolStripMenuItem1.Click += new System.EventHandler(this.takeTestToolStripMenuItem1_Click);
            // 
            // cancleAppointmentToolStripMenuItem
            // 
            this.cancleAppointmentToolStripMenuItem.Image = global::DVLD_Presentation.Properties.Resources.cancle;
            this.cancleAppointmentToolStripMenuItem.Name = "cancleAppointmentToolStripMenuItem";
            this.cancleAppointmentToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.cancleAppointmentToolStripMenuItem.Text = "Cancle Appointment";
            this.cancleAppointmentToolStripMenuItem.Click += new System.EventHandler(this.cancleAppointmentToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 601);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Appointmets:";
            // 
            // btnAddAppointments
            // 
            this.btnAddAppointments.FlatAppearance.BorderSize = 0;
            this.btnAddAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointments.Image = global::DVLD_Presentation.Properties.Resources.plus_small;
            this.btnAddAppointments.Location = new System.Drawing.Point(957, 589);
            this.btnAddAppointments.Name = "btnAddAppointments";
            this.btnAddAppointments.Size = new System.Drawing.Size(68, 61);
            this.btnAddAppointments.TabIndex = 7;
            this.btnAddAppointments.UseVisualStyleBackColor = true;
            this.btnAddAppointments.Click += new System.EventHandler(this.btnAddAppointments_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::DVLD_Presentation.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(883, 589);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(68, 61);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ctrlLocalLicenseApplicationInfo1
            // 
            this.ctrlLocalLicenseApplicationInfo1.Location = new System.Drawing.Point(5, 105);
            this.ctrlLocalLicenseApplicationInfo1.Name = "ctrlLocalLicenseApplicationInfo1";
            this.ctrlLocalLicenseApplicationInfo1.Size = new System.Drawing.Size(1020, 483);
            this.ctrlLocalLicenseApplicationInfo1.TabIndex = 1;
            // 
            // lbPassedMessage
            // 
            this.lbPassedMessage.AutoSize = true;
            this.lbPassedMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassedMessage.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lbPassedMessage.Location = new System.Drawing.Point(348, 105);
            this.lbPassedMessage.Name = "lbPassedMessage";
            this.lbPassedMessage.Size = new System.Drawing.Size(310, 29);
            this.lbPassedMessage.TabIndex = 10;
            this.lbPassedMessage.Text = "Successfully Passed This";
            // 
            // lbTrails
            // 
            this.lbTrails.AutoSize = true;
            this.lbTrails.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTrails.Location = new System.Drawing.Point(541, 601);
            this.lbTrails.Name = "lbTrails";
            this.lbTrails.Size = new System.Drawing.Size(52, 29);
            this.lbTrails.TabIndex = 11;
            this.lbTrails.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(430, 601);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Trail:";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_Presentation.Properties.Resources.age;
            this.pictureBox7.Location = new System.Drawing.Point(508, 605);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(27, 25);
            this.pictureBox7.TabIndex = 53;
            this.pictureBox7.TabStop = false;
            // 
            // SechdualeTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 867);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTrails);
            this.Controls.Add(this.lbPassedMessage);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddAppointments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pbFromImage);
            this.Controls.Add(this.ctrlLocalLicenseApplicationInfo1);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SechdualeTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SechdualeTestForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SechdualeTestForm_FormClosed);
            this.Load += new System.EventHandler(this.SechdualeTestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFromImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private UserControls.ctrlLocalLicenseApplicationInfo ctrlLocalLicenseApplicationInfo1;
        private System.Windows.Forms.PictureBox pbFromImage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAppointments;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancleAppointmentToolStripMenuItem;
        private System.Windows.Forms.Label lbPassedMessage;
        private System.Windows.Forms.Label lbTrails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}