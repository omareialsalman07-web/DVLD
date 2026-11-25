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
        private TestAppointment _TestAppointment;
        private DVLD_Business.LocalLicenseApplication _LocalLicenseApplication;
        public float TotalFees { get; private set; }
        private Test _Test;
        public ctrlTestAppointmentInfo()
        {
            InitializeComponent();
            _LocalLicenseApplication = null;
            _Test = null;
        }
        public void LoadTestAppointmentInfo(int TestAppointmentID, enMode mode)
        {
            dateTimePicker1.MinDate = DateTime.Today;

            try
            {
                _Mode = mode;
                _TestAppointment = TestAppointmentService.Find(TestAppointmentID);
                if (_TestAppointment == null)
                {
                    ShowErrorMessage($"Couldn't find Test Appointment.\n\n{TestAppointmentID}");
                    return;
                }
                _Test = _TestAppointment.TestInfo;

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


        public void LoadInitialTestAppointmentInfo(enTestType TestType, int LocalLicenseApplicationID, enMode Mode)
        {
            try
            {
                _TestAppointment = null;
                _Mode = Mode;
                _Test = new Test(-1, TestType, TestType, null, "", LocalLicenseApplicationID, DVLD_Settings.GetCurrnetUser().ID); // temp test for show

                InitializeFormTitle();
                LoadTestInformation();
                LoadRetakeTestInformation();
                UpdateTotalFees();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while loading the test appointment information.\n\n{ex.Message}");
            }
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
            lbLocalLicenseID.Text = _Test.LocalLicenseApplicationInfo.LocalLicenseApplicationID.ToString();

            lbTestID.Text = (_Test.TestID == -1)? "N/A" : _Test.TestID.ToString();
            switch(_Mode)
            {
                case enMode.eShow:
                    dateTimePicker1.Value = _TestAppointment.Date;
                    dateTimePicker1.Enabled = false;
                    break;
                case enMode.eAddNew:
                    dateTimePicker1.Value = DateTime.Today;
                    break;
                case enMode.eEdit:
                    dateTimePicker1.Value = _TestAppointment.Date;
                    break;
            }

            LoadLicenseClassInformation();
            LoadPersonInformation();
            LoadTestStatistics();
        }

        private void LoadLicenseClassInformation()
        {
            lbClass.Text = _Test.LocalLicenseApplicationInfo.LicenseClassInfo.ClassName;
        }

        private void LoadPersonInformation()
        {
            lbPersonName.Text = _Test.LocalLicenseApplicationInfo.PersonInfo.FirstName + " " 
                + _Test.LocalLicenseApplicationInfo.PersonInfo.FirstName;
        }

        private void LoadTestStatistics()
        {
            lbTrails.Text = LocalLicenseApplicationService.GetTotalTestTrials(_Test.LocalLicenseApplicationInfo.LocalLicenseApplicationID, _Test.TestType).ToString();

            float testFees = TestTypeService.Find((int)_Test.TestType).Fees;

            lbFees.Text = testFees.ToString();

            TotalFees = testFees;
        }
        private void LoadRetakeTestInformation()
        {
            float retakeFees = ApplicationTypeService.Find((int)enApplicationType.eRetakeTest).Fees;

            if (_Mode == enMode.eAddNew)
            {
                if (LocalLicenseApplicationService.HasTakenTestAppointment(_Test.LocalLicenseApplicationInfo.LocalLicenseApplicationID, _Test.TestType))
                {
                    lb_RetakeTestAppID.Text = "N/A";
                    lbRetakeFees.Text = retakeFees.ToString();
                }
                else
                {
                    groupBoxReTakeTest.Enabled = false;
                    retakeFees = 0;
                }
            }
            else
            {
                if (_TestAppointment.RetakeTestApplicationInfo != null)
                {
                    lb_RetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationInfo.ApplicationID.ToString();
                    lbRetakeFees.Text = retakeFees.ToString();
                }
                else
                {
                    groupBoxReTakeTest.Enabled = false;
                    retakeFees = 0;
                }
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
