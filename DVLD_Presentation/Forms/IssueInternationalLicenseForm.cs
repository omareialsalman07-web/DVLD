using DVLD_Business;
using DVLD_Presentation.UserControls;
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
    public partial class IssueInternationalLicenseForm : Form
    {
        private bool _IssueInternationLicense;
        int _CreatedForDriverID;
        public IssueInternationalLicenseForm()
        {
            InitializeComponent();
            _IssueInternationLicense = false;
            _CreatedForDriverID = -1;
        }

        private void _OnSelectLocalLicese(bool isValid)
        {
            if(isValid && !_IssueInternationLicense)
            {
                btnIssue.Enabled = true;
            }
            else
                btnIssue.Enabled = false;
        }

        private void IssueInternationalLicenseForm_Load(object sender, EventArgs e)
        {
            ctrlBasicApplicationInfo1.LoadLockupApplication(DVLD_Business.enApplicationType.eNewInternationalLicense);
            ctrlLicenseSelector1.onSelectLicense += _OnSelectLocalLicese;

            lknl_ShowLicenseInfo.Enabled = false;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedLicenseID = -1; ctrlLicenseSelector.enSelectedLiceseType selectedLiceseType = ctrlLicenseSelector.enSelectedLiceseType.eNone;
                ctrlLicenseSelector1.GetSelectedLicese(ref selectedLicenseID, ref selectedLiceseType);
                if (selectedLicenseID == -1 || selectedLiceseType == ctrlLicenseSelector.enSelectedLiceseType.International)
                {
                    MessageBox.Show($"Please select a valid Local License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int IL_ID = InternationalLicenseService.CreateFirstTime(selectedLicenseID, DVLD_Settings.GetCurrnetUser().ID);
                if (IL_ID == -1)
                {
                    MessageBox.Show($"Faild To CreateFirstTime International License from the local license id [{selectedLicenseID}]!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Successfully Created International License with ID [{IL_ID}]!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InternationalLicense internationalLicense = InternationalLicenseService.FindByInternationalID(IL_ID);
                DVLD_Business.License license = LicenseService.FindByLicenseID(internationalLicense.LicenseID);
                ctrlBasicApplicationInfo1.LoadApplication(license.ApplicationID);

                _CreatedForDriverID = license.DriverID;
                btnIssue.Enabled = false;
                _IssueInternationLicense = true;
                lknl_ShowLicenseInfo.Enabled = true;

                ctrlLicenseSelector1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lknl_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_CreatedForDriverID == -1)
                return;

            Form licenseHistoryForm = new LicensesHistoryForm(_CreatedForDriverID);
            licenseHistoryForm.ShowDialog();
        }
    }
}
