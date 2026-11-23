using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlLicenseSelector : UserControl
    {
        public enum enSelectedLiceseType { eNone, Local, International };
        enSelectedLiceseType _SelectedLiceseType;
        public delegate void OnSelectLicense(bool isValid);
        public OnSelectLicense onSelectLicense;

        private int _SelectedLicenseID;
        public ctrlLicenseSelector()
        {
            InitializeComponent();
            _SelectedLicenseID = -1;
            _SelectedLiceseType = enSelectedLiceseType.eNone;
        }

        private void _SelectLocalLicense()
        {
            int _ID = Convert.ToInt32(txb_LicenseID.Text);

            LocalLicense localLicense = LocalLicenseService.Find(_ID);
            
            if (localLicense == null)
            {
                MessageBox.Show($"Can't {_SelectedLiceseType} License with _ID [{_ID}]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!localLicense.IsActive)
            {
                MessageBox.Show($"The {_SelectedLiceseType} License with _ID [{_ID}] should be active!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlLocalLicenseInfo1.Enabled = false;
                _SelectedLicenseID = -1;
                onSelectLicense?.Invoke(false);
                return;
            }

            ctrlLocalLicenseInfo1.Enabled = true;
            _SelectedLicenseID = _ID;
            onSelectLicense?.Invoke(true);
            ctrlLocalLicenseInfo1.LoadLocalLicense(_ID);
        }

        private void _SelectInternationalLicense()
        {
            int _ID = Convert.ToInt32(txb_LicenseID.Text);

           InternationalLicense internationalLicense = InternationalLicenseService.FindByInternationalID(_ID);

            if (internationalLicense == null)
            {
                MessageBox.Show($"Can't {_SelectedLiceseType} License with _ID [{_ID}]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!internationalLicense.IsActive)
            {
                MessageBox.Show($"The {_SelectedLiceseType} License with _ID [{_ID}] should be active!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlInternationalLicenseInfo1.Enabled = false;
                onSelectLicense?.Invoke(false);
                _SelectedLicenseID = -1;
                return;
            }

            ctrlInternationalLicenseInfo1.Enabled = true;
            onSelectLicense?.Invoke(true);
            ctrlInternationalLicenseInfo1.LoadInternaitonalLicense(_ID);
            _SelectedLicenseID = _ID;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txb_LicenseID.Text))
                    return;

                if(_SelectedLiceseType == enSelectedLiceseType.Local)
                {
                    _SelectLocalLicense();
                }
                else
                {
                    _SelectInternationalLicense();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlLocalLicenseSelector_Load(object sender, EventArgs e)
        {
            rb_Local.Checked = true;
        }

        public void GetSelectedLicese(ref int LicenseID, ref enSelectedLiceseType LicenseType)
        {
            LicenseID = _SelectedLicenseID;
            LicenseType = _SelectedLiceseType;
        }

        public void SetOnlyLocalSelect()
        {
            rb_International.Enabled = false;
        }

        private void rb_Local_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_International.Checked)
            {
                _SelectedLiceseType = enSelectedLiceseType.International;
                ctrlInternationalLicenseInfo1.Visible = true;
                ctrlLocalLicenseInfo1.Visible = false;
            }
            else
            {
                _SelectedLiceseType = enSelectedLiceseType.Local;
                ctrlLocalLicenseInfo1.Visible = true;
                ctrlInternationalLicenseInfo1.Visible = false;
            }
        }
    }
}
