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
    public partial class ReplacementForLostorDamagedLicenseForm : Form
    {
        int _CreatedForDriverID;
        private bool _ReplacedLicense;
        DVLD_Business.License _SelectedLicese;

        public ReplacementForLostorDamagedLicenseForm()
        {
            InitializeComponent();
            _CreatedForDriverID = -1;
            _ReplacedLicense = false;
        }

        private void _OnSelectLicense(bool isValid)
        {
            if (!isValid || _ReplacedLicense)
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

        private void ReplacementForLostorDamagedLicenseForm_Load(object sender, EventArgs e)
        {
            ctrlBasicApplicationInfo1.LoadLockupApplication(enApplicationType.eRenewDrivingLicense);

            ctrlLicenseSelector1.onSelectLicense += _OnSelectLicense;
        }

        private void lknl_ShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (_CreatedForDriverID == -1)
                return;

            Form licenseHistoryForm = new LicensesHistoryForm(_CreatedForDriverID);
            licenseHistoryForm.ShowDialog();
        }

        private void btn_Renew_Click(object sender, EventArgs e)
        {
            try
            {
                if(rb_Lost.Checked == false && rb_Damaged.Checked == false)
                {
                    MessageBox.Show($"Please select service type (eiter replacement for lost or damaged)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_SelectedLicese == null)
                {
                    MessageBox.Show($"Please select a valid License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newLicenseID = -1;
                if (_SelectedLicese is DVLD_Business.LocalLicense local)
                {
                    if(rb_Lost.Checked)
                        newLicenseID = LocalLicenseService.ReplacementForLost(local.LicenseID, DVLD_Settings.GetCurrnetUser().ID);
                    else
                        newLicenseID = LocalLicenseService.ReplacementForDamage(local.LicenseID, DVLD_Settings.GetCurrnetUser().ID);
                }
                else if (_SelectedLicese is DVLD_Business.InternationalLicense international)
                {
                    if (rb_Lost.Checked)
                        newLicenseID = InternationalLicenseService.ReplacementForLost(international.LicenseID, DVLD_Settings.GetCurrnetUser().ID);
                    else
                        newLicenseID = InternationalLicenseService.ReplacementForLost(international.LicenseID, DVLD_Settings.GetCurrnetUser().ID);
                }

                if (newLicenseID == -1)
                {
                    MessageBox.Show($"Faild To Renew License for driver ID [{_SelectedLicese.DriverInfo}]!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Successfully Created International License with ID [{newLicenseID}]!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlBasicApplicationInfo1.LoadApplication(_SelectedLicese.ApplicationInfo.ApplicationID);

                _CreatedForDriverID = _SelectedLicese.DriverInfo.DriverID;
                btn_Renew.Enabled = false;
                _ReplacedLicense = true;
                lknl_ShowLicenseInfo.Enabled = true;

                ctrlLicenseSelector1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
