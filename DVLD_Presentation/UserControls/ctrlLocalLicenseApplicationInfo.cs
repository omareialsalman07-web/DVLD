using DVLD_Business;
using DVLD_Presentation.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlLocalLicenseApplicationInfo : UserControl
    {
        private DVLD_Business.LocalLicenseApplication _LocalLicenseApplication = null;

        public ctrlLocalLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void ctrlLocalLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadLocalLicenseApplication(int LLApplicationID)
        {
            try
            {
                _LocalLicenseApplication = LocalLicenseApplicationService.Find(LLApplicationID);
                if(_LocalLicenseApplication == null)
                {
                    MessageBox.Show
                        (
                        "Local License Application not found!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );

                    return;
                }

                lbID.Text = _LocalLicenseApplication.LocalLicenseApplicationID.ToString();
                lbApplicedLicenseClass.Text = LicenseClassService.Find(_LocalLicenseApplication.LicenseClassID).ClassName;
                lbPassedTests.Text = LocalLicenseApplicationService.GetTotalPassedTests(_LocalLicenseApplication.LocalLicenseApplicationID).ToString() + "/3";
                ctrlBasicApplicationInfo1.LoadApplication(_LocalLicenseApplication.ApplicationID);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_LocalLicenseApplication == null)
            {
                MessageBox.Show("Some thing went wrong! Local License Application in null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form personCardForm = new PersonCardForm(_LocalLicenseApplication.PersonID);
            personCardForm.ShowDialog();
        }
    }
}
