using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Forms
{
    public partial class TakeTestAppointmentForm : Form
    {
        public delegate void OnTakeTestAppointmentForm_Finish(bool result);
        public OnTakeTestAppointmentForm_Finish onTakeTestAppointmentForm_Finish;

        int _TestAppointmentID;
        public TakeTestAppointmentForm(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            int TestID = TestAppointmentService.Find(TestAppointmentID).TestID;
            ctrlTestAppointmentInfo1.LoadTestAppointmentInfo(TestID,  UserControls.ctrlTestAppointmentInfo.enMode.eShow, TestAppointmentID);
        }

        private void TakeTestAppointmentForm_Load(object sender, EventArgs e)
        {
            rbFail.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rbFail.Checked && !rbPass.Checked)
            {
                MessageBox.Show("You have to identify the result!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool result = rbPass.Checked;
            try
            {
                if(TestAppointmentService.TakeTest(_TestAppointmentID, result, textBoxNotes.Text))
                {
                    MessageBox.Show("The test was taken successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Some thing went wrong wile taking the test!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TakeTestAppointmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            onTakeTestAppointmentForm_Finish?.Invoke(rbPass.Checked);
        }
    }
}
