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
using static DVLD_Presentation.Forms.AddEditTestAppointmentForm;

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlTestAppointmentInfo : UserControl
    {
        public enum enMode { eShow, eAddNew, eEdit };
        enMode _Mode;

        private Test _Test;
        private int _TestAppointmentID;
        int _TestID;
        public float TotalFees { get; private set; }

        public int RetakeTestApplicationID { get; private set; }

        public ctrlTestAppointmentInfo()
        {
            InitializeComponent();
            RetakeTestApplicationID = -1;
        }
        public void LoadTestAppointmentInfo(int TestID, enMode Mode, int TestAppointmentID = -1)
        {
            dateTimePicker1.MinDate = DateTime.Today;

            try
            {
                _TestID = TestID;
                _LoadTest();
                _TestAppointmentID = TestAppointmentID;
                _Mode = Mode;

                if (!IsTestValid())
                    return;

                InitializeFormTitle();
                LoadTestInformation();
                LoadRetakeTestInformation();
                UpdateTotalFees();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    $"An error occurred while loading the test appointment information.\n\n{ex.Message}");
            }
        }

        private void _LoadTest() 
        {
            _Test = TestService.Find(_TestID);
            if (_Test.Result == false) // failed 
                _Test = TestService.Find(TestService.CreateTest(_Test.TestType, _Test.LocalLicenseApplicationID, DVLD_Settings.GetCurrnetUser().ID));
        }

        private bool IsTestValid()
        {
            if (_Test != null)
                return true;

            ShowErrorMessage($"Test with ID {_TestID} was not found.");
            return false;
        }

        private void InitializeFormTitle()
        {
            switch (_Mode)
            {
                case enMode.eShow:
                    lbTitle.Text = "";
                    break;
                case enMode.eAddNew:
                    lbTitle.Text = "Add ";
                    break;
                case enMode.eEdit:
                    lbTitle.Text = "Edit ";
                    break;
            }

            switch (_Test.TestType)
            {
                case enTestType.eVisionTest:
                    lbTitle.Text += "Vision Test Appointment";
                    pbFromImage.Image = Resources.eye_scan;
                    break;
                case enTestType.eWrittenTest:
                    lbTitle.Text += "Written Test Appointment";
                    pbFromImage.Image = Resources.content;
                    break;

                case enTestType.ePracticalTest:
                    lbTitle.Text += "Street Test Appointment";
                    pbFromImage.Image = Resources.road;
                    break;
            }
        }

        private void LoadTestInformation()
        {
            lbLocalLicenseID.Text =
                _Test.LocalLicenseApplicationID.ToString();

            lbTestID.Text = _Test.TestID.ToString();
            switch(_Mode)
            {
                case enMode.eShow:
                    dateTimePicker1.Value = TestAppointmentService.Find(_TestAppointmentID).Date;
                    dateTimePicker1.Enabled = false;
                    break;
                case enMode.eAddNew:
                    dateTimePicker1.Value = DateTime.Today;
                    break;
                case enMode.eEdit:
                    dateTimePicker1.Value = TestAppointmentService.Find(_TestAppointmentID).Date;
                    break;
            }

            LoadLicenseClassInformation();
            LoadPersonInformation();
            LoadTestStatistics();
        }

        private void LoadLicenseClassInformation()
        {
            int localLicenseID = _Test.LocalLicenseApplicationID;

            int licenseClassID =
                LocalLicenseApplicationService.Find(localLicenseID).LicenseClassID;

            lbClass.Text =
                LicenseClassService.Find(licenseClassID).ClassName;
        }

        private void LoadPersonInformation()
        {
            int localLicenseID = _Test.LocalLicenseApplicationID;

            int personID =
                LocalLicenseApplicationService.Find(localLicenseID).PersonID;

            Person person = PersonService.Find(personID);

            lbPersonName.Text =
                person.FirstName + " " + person.LastName;
        }

        private void LoadTestStatistics()
        {
            lbTrails.Text =
                LocalLicenseApplicationService.GetTotalTestTrials(_Test.LocalLicenseApplicationID, _Test.TestType).ToString();

            float testFees =
                TestTypeService.Find((int)_Test.TestType).Fees;

            lbFees.Text = testFees.ToString();

            TotalFees = testFees;
        }
        private void LoadRetakeTestInformation()
        {
            if (_Mode == enMode.eAddNew)
            {
                if (LocalLicenseApplicationService.HasTakenTestAppointment(_Test.LocalLicenseApplicationID, _Test.TestType))
                {
                    RetakeTestApplicationID = ApplicationService.Create(
                        (int)enApplicationType.eRetakeTest,
                        dateTimePicker1.Value,
                        (int)enApplicationStatus.eNew,
                        DVLD_Settings.GetCurrnetUser().ID);
                }
            }
            else
            {
                RetakeTestApplicationID = TestAppointmentService.Find(_TestAppointmentID).RetakeTestApplicationID;
            }

            float retakeFees = 0;
            if (RetakeTestApplicationID != -1)
            {
                retakeFees =
                    ApplicationTypeService.Find(
                        (int)enApplicationType.eRetakeTest).Fees;

                lb_RetakeTestAppID.Text =
                    RetakeTestApplicationID.ToString();

                lbRetakeFees.Text = retakeFees.ToString();
            }
            else
            {
                groupBoxReTakeTest.Enabled = false;
            }

            TotalFees += retakeFees;
        }

        private void UpdateTotalFees()
        {
            lbTotalFees.Text = TotalFees.ToString();
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

        public DateTime GetSelectedDateTime()
        {
            return dateTimePicker1.Value;
        }

        public int GetCurrentTestID()
        {
            return _Test.TestID;
        }
    }
}
