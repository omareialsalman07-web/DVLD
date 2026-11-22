using DVLD_Business;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Forms
{
    public partial class SechdualeTestForm : Form
    {
        public delegate void OnSechdualeTestFormClose();
        public OnSechdualeTestFormClose onSechdualeTestFormClose;

        private int _LocalLicenseApplicationID;
        private int _SelectedAppointment_ID = -1;
        enTestType _TestType;
        public SechdualeTestForm(int LocalLicenseApplication, enTestType TestType)
        {
            InitializeComponent();
            _LocalLicenseApplicationID = LocalLicenseApplication;
            _TestType = TestType;

        }

        private void _LoadAppointments()
        {
            try
            {
                dataGridView1.DataSource = TestAppointmentService.GetAppointmentsForDisplay(_LocalLicenseApplicationID, _TestType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SechdualeTestForm_Load(object sender, EventArgs e)
        {
            lbPassedMessage.Visible = false;

            ctrlLocalLicenseApplicationInfo1.LoadLocalLicenseApplication(_LocalLicenseApplicationID);
            switch(_TestType)
            {
                case enTestType.eVisionTest:
                    lbTitle.Text = "Vision Test Appointments";
                    pbFromImage.Image = Resources.eye_scan;
                    break;
                case enTestType.eWrittenTest:
                    lbTitle.Text = "Written Test Appointments";
                    pbFromImage.Image = Resources.content;
                    break;
                case enTestType.ePracticalTest:
                    lbTitle.Text = "Street Test Appointments";
                    pbFromImage.Image = Resources.drivingTest;
                    break;
            }

            _Refresh();
        }

        private void btnAddAppointments_Click(object sender, EventArgs e)
        {
            try
            {
                if(!TestAppointmentService.CanCreateAppointment(_LocalLicenseApplicationID))
                {
                    MessageBox.Show("Can't Crete an appointment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddEditTestAppointmentForm addEditAppointmentForm = new AddEditTestAppointmentForm(_LocalLicenseApplicationID, _TestType, AddEditTestAppointmentForm.enMode.eAddNew);
                addEditAppointmentForm.onAddEditTestAppointmentFormFinish += _LoadAppointments;
                addEditAppointmentForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _Refresh()
        {
            _LoadAppointments();
            lbTrails.Text = LocalLicenseApplicationService.GetTotalTestTrials(_LocalLicenseApplicationID, _TestType).ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                _SelectedAppointment_ID = -1;
                return;
            }
            _SelectedAppointment_ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
        }

        private void cancleAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedAppointment_ID == -1)
            {
                MessageBox.Show("Selected an appointment to cancel!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TestAppointmentService.IsValidAppointment(_SelectedAppointment_ID))
            {
                MessageBox.Show("Can't cancel this appointment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TestAppointmentService.CancleAppointment(_SelectedAppointment_ID))
            {
                MessageBox.Show("Successfuly Cancled this appointment!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh();
            }
        }

        private void EditTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_SelectedAppointment_ID == -1)
            { 
                MessageBox.Show("Selected an appointment to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TestAppointmentService.IsValidAppointment(_SelectedAppointment_ID))
            {
                MessageBox.Show("Can't edit this appointment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddEditTestAppointmentForm addEditAppointmentForm = new AddEditTestAppointmentForm(_LocalLicenseApplicationID, _TestType, AddEditTestAppointmentForm.enMode.eEdit, _SelectedAppointment_ID);
            addEditAppointmentForm.onAddEditTestAppointmentFormFinish += _LoadAppointments;
            addEditAppointmentForm.ShowDialog();
        }

        private void _OnTakeTestAppointmentForm_Finish(bool result)
        {
            _Refresh();
           
            if(result == true)
            {
                btnAddAppointments.Enabled = false;
                btnRefresh.Enabled = false;
                dataGridView1.Enabled = false;
                lbPassedMessage.Visible = true;
                ctrlLocalLicenseApplicationInfo1.LoadLocalLicenseApplication(_LocalLicenseApplicationID);
            }
        }

        private void takeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_SelectedAppointment_ID == -1)
            {
                MessageBox.Show("Selected an appointment to take!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(!TestAppointmentService.CanTakeTest(_SelectedAppointment_ID))
            {
                MessageBox.Show("Selected appointment can't be taken!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TakeTestAppointmentForm form = new TakeTestAppointmentForm(_SelectedAppointment_ID);
            form.onTakeTestAppointmentForm_Finish += _OnTakeTestAppointmentForm_Finish;
            form.ShowDialog();
        }

        private void SechdualeTestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            onSechdualeTestFormClose?.Invoke();
            this.Close();
        }
    }
}
