
using DVLD_Business;
using DVLD_Presentation.Properties;
using DVLD_Presentation.UserControls;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation.Forms
{
    public partial class AddEditTestAppointmentForm : Form
    {
        public enum enMode { eAddNew, eEdit }
        public delegate void OnAddEditTestAppointmentFormFinish();
        public OnAddEditTestAppointmentFormFinish onAddEditTestAppointmentFormFinish;

        private enMode _Mode;
        private int _TestID;
        private int _TestAppointmentID;

        public AddEditTestAppointmentForm(int TestID, enMode Mode, int TestAppointmentID = -1)
        {
            InitializeComponent();

            _TestID = TestID;
            _Mode = Mode;
            _TestAppointmentID = TestAppointmentID;
        }

        private void AddEditTestAppointmentForm_Load(object sender, EventArgs e)
        {
            ctrlTestAppointmentInfo.enMode mode = (_Mode == enMode.eAddNew) ? ctrlTestAppointmentInfo.enMode.eAddNew
                : ctrlTestAppointmentInfo.enMode.eEdit;
            ctrlTestAppointmentInfo1.LoadTestAppointmentInfo(_TestID, mode, _TestAppointmentID);
        }

        bool bSaved = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Mode == enMode.eAddNew)
                    AddNewAppointment();
                else
                    UpdateAppointment();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            onAddEditTestAppointmentFormFinish?.Invoke();
            bSaved = true;
            this.Close();
        }

        private void AddNewAppointment()
        {
            Test _Test = TestService.Find(ctrlTestAppointmentInfo1.GetCurrentTestID());

            if (TestAppointmentService.ScheduleAppointment(
                _Test.TestID,
                ctrlTestAppointmentInfo1.GetSelectedDateTime(),
                ctrlTestAppointmentInfo1.TotalFees,
                DVLD_Settings.GetCurrnetUser().ID,
                ctrlTestAppointmentInfo1.RetakeTestApplicationID) == -1)
            {
                ShowErrorMessage(
                    $"Failed to schedule an appointment for Test ID {_Test.TestID}.");

                return;
            }

            ShowInformationMessage("Test appointment added successfully.");
        }

        private void UpdateAppointment()
        {
            if (!TestAppointmentService.UpdateAppointmentDate(
                _TestAppointmentID,
                ctrlTestAppointmentInfo1.GetSelectedDateTime()))
            {
                ShowErrorMessage(
                    $"Failed to update the appointment (ID: {_TestAppointmentID}).");

                return;
            }

            ShowInformationMessage("Test appointment updated successfully.");
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(
                message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void ShowInformationMessage(string message)
        {
            MessageBox.Show(
                message,
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void AddEditTestAppointmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_Mode != enMode.eAddNew || bSaved != false)
                return;

            int RetakeTestApplicationID = ctrlTestAppointmentInfo1.RetakeTestApplicationID;
            if (ctrlTestAppointmentInfo1.RetakeTestApplicationID != -1)
                ApplicationService.Delete(RetakeTestApplicationID);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            bSaved = false;
            this.Close();
        }
    }
}
