
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
        private int _LocalLicenseApplicationID;
        private int _TestAppointmentID;
        private enTestType _TestType;

        public AddEditTestAppointmentForm(int LocalLicenseApplicationID, enTestType TestType, enMode Mode, int TestAppointmentID = -1)
        {
            InitializeComponent();

            _LocalLicenseApplicationID = LocalLicenseApplicationID;
            _Mode = Mode;
            _TestAppointmentID = TestAppointmentID;
            _TestType = TestType;
        }

        private void AddEditTestAppointmentForm_Load(object sender, EventArgs e)
        {
            _SetupForm();
        }

        private void _SetupForm()
        {
            ctrlTestAppointmentInfo.enMode mode = (_Mode == enMode.eAddNew) ? ctrlTestAppointmentInfo.enMode.eAddNew
               : ctrlTestAppointmentInfo.enMode.eEdit;

            if (_Mode == enMode.eAddNew)
                ctrlTestAppointmentInfo1.LoadInitialTestAppointmentInfo(_TestType, _LocalLicenseApplicationID, mode);
            else
                ctrlTestAppointmentInfo1.LoadTestAppointmentInfo(_TestAppointmentID, mode);
        }


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

            
            this.Close();
        }

        private void AddNewAppointment()
        {
            if (TestAppointmentService.ScheduleAppointment(_LocalLicenseApplicationID, _TestType,
                ctrlTestAppointmentInfo1.GetSelectedDateTime(), ctrlTestAppointmentInfo1.TotalFees, 
                DVLD_Settings.GetCurrnetUser().ID) == -1)
            {
                ShowErrorMessage(
                    $"Failed to schedule an appointment for Local license applicaiton {_LocalLicenseApplicationID}.");

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
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
