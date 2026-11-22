using DVLD_Business;
using DVLD_Presentation.Properties;
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
using static DVLD_Presentation.UserControls.ctrlLicenseSelector;

namespace DVLD_Presentation.Forms
{
    public partial class DetainedReleasedForm : Form
    {
        public delegate void OnDetainedReleasedFormClose();
        public OnDetainedReleasedFormClose onDetainedReleasedFormClose;

        public enum enMode { eDetain, eRelease };
        enMode _Mode;

        private bool _Detained_ReleasedLicense;
        int _Detained_ReleasedForDriverID;
        DVLD_Business.License _SelectedLicese;

        public DetainedReleasedForm(enMode mode)
        {
            InitializeComponent();
            _Mode = mode;

            _Detained_ReleasedForDriverID = -1;
            _Detained_ReleasedLicense = false;
        }

        private void _OnSelectLicense(bool isValid)
        {
            if (!isValid || _Detained_ReleasedLicense)
            {
                _SelectedLicese = null;
                btn_Detain_Release.Enabled = false;
                return;
            }

            btn_Detain_Release.Enabled = true;
            int ID = -1; ctrlLicenseSelector.enSelectedLiceseType selectedLiceseType = ctrlLicenseSelector.enSelectedLiceseType.eNone;
            ctrlLicenseSelector1.GetSelectedLicese(ref ID, ref selectedLiceseType);

            _SelectedLicese = (selectedLiceseType == ctrlLicenseSelector.enSelectedLiceseType.Local)
                ? (DVLD_Business.License)LocalLicenseService.FindByLocalLicenseID(ID)
                : InternationalLicenseService.FindByInternationalID(ID);
        }

        private void DetainedReleasedForm_Load(object sender, EventArgs e)
        {
            ctrlLicenseSelector1.onSelectLicense += _OnSelectLicense;

            if (_Mode == enMode.eDetain)
            {
                btn_Detain_Release.Text = "Detain";
                btn_Detain_Release.Image = Resources.Detain_32;
                ctrlBasicApplicationInfo1.Visible = false;
            }
            else
            {
                btn_Detain_Release.Text = "Release";
                btn_Detain_Release.Image = Resources.Release_Detained_License_32;
                panel1.Visible = false;
                ctrlBasicApplicationInfo1.LoadLockupApplication(enApplicationType.eReleaseDetainedDrivingLicense);
            }
        }

        private void btn_Detain_Release_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SelectedLicese == null)
                {
                    MessageBox.Show($"Please select a valid License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_Mode == enMode.eDetain)
                {
                    float fees = Convert.ToSingle(mtxb_FineFees.Text);
                    if (DetainedLicenseService.Detain(_SelectedLicese.LicenseID, fees, DVLD_Settings.GetCurrnetUser().ID) != -1)
                        MessageBox.Show($"Successfully Detained License with ID [{_SelectedLicese.LicenseID}]!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"un able to Detaine License with ID [{_SelectedLicese.LicenseID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(DetainedLicenseService.Release(_SelectedLicese.LicenseID, DVLD_Settings.GetCurrnetUser().ID))
                        MessageBox.Show($"Successfully Released License with ID [{_SelectedLicese.LicenseID}]!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"un able to Release License with ID [{_SelectedLicese.LicenseID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if(_Mode == enMode.eRelease)
                    ctrlBasicApplicationInfo1.LoadApplication(_SelectedLicese.ApplicationID);

                _Detained_ReleasedForDriverID = _SelectedLicese.DriverID;
                btn_Detain_Release.Enabled = false;
                _Detained_ReleasedLicense = true;
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
            if (_Detained_ReleasedForDriverID == -1)
                return;

            Form licenseHistoryForm = new LicensesHistoryForm(_Detained_ReleasedForDriverID);
            licenseHistoryForm.ShowDialog();
        }

        private void DetainedReleasedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            onDetainedReleasedFormClose?.Invoke();
        }
    }
}
