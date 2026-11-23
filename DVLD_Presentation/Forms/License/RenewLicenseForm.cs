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
    public partial class RenewLicenseForm : Form
    {
        int _CreatedForDriverID;
        private bool _RenewedLicense;
        DVLD_Business.License _SelectedLicese;
        public RenewLicenseForm()
        {
            InitializeComponent();

            _CreatedForDriverID = -1;
            _RenewedLicense = false;
        }

        private void lknl_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_CreatedForDriverID == -1)
                return;

            Form licenseHistoryForm = new LicensesHistoryForm(_CreatedForDriverID);
            licenseHistoryForm.ShowDialog();
        }

        private void _OnSelectLicense(bool isValid)
        {
            if (!isValid || _RenewedLicense)
            {
                _SelectedLicese = null;
                btn_Renew.Enabled = false;
                return;
            }

            btn_Renew.Enabled = true;
            int ID = -1; ctrlLicenseSelector.enSelectedLiceseType selectedLiceseType = ctrlLicenseSelector.enSelectedLiceseType.eNone;
            ctrlLicenseSelector1.GetSelectedLicese(ref ID, ref selectedLiceseType);

            _SelectedLicese = (selectedLiceseType == ctrlLicenseSelector.enSelectedLiceseType.Local)
                ? (DVLD_Business.License)LocalLicenseService.Find(ID) 
                : InternationalLicenseService.FindByInternationalID(ID);

        }

        private void RenewLicenseForm_Load(object sender, EventArgs e)
        {
            ctrlBasicApplicationInfo1.LoadLockupApplication(enApplicationType.eRenewDrivingLicense);

            ctrlLicenseSelector1.onSelectLicense += _OnSelectLicense;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedLicese == null)
                {
                    MessageBox.Show($"Please select a valid License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newLicenseID = -1;
                if (_SelectedLicese is DVLD_Business.LocalLicense local)
                {
                    newLicenseID = LocalLicenseService.Renew(local.LicenseID, DVLD_Settings.GetCurrnetUser().ID);
                }
                else if (_SelectedLicese is DVLD_Business.InternationalLicense international)
                {
                    newLicenseID = InternationalLicenseService.Renew(international.LicenseID, DVLD_Settings.GetCurrnetUser().ID);
                }

                if (newLicenseID == -1)
                {
                    MessageBox.Show($"Faild To Renew License for driver ID [{_SelectedLicese.DriverID}]!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Successfully Created International License with ID [{newLicenseID}]!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlBasicApplicationInfo1.LoadApplication(_SelectedLicese.ApplicationID);

                _CreatedForDriverID = _SelectedLicese.DriverID;
                btn_Renew.Enabled = false;
                _RenewedLicense = true;
                lknl_ShowLicenseInfo.Enabled = true;

                ctrlLicenseSelector1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lknl_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
