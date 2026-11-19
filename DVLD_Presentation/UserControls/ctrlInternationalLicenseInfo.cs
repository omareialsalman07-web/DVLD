using DVLD_Business;
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
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void InternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadInternaitonalLicense(int internationalLicenseID)
        {
            InternationalLicense internationalLicense = InternationalLicenseService.FindByInternationalID(internationalLicenseID);
            if(internationalLicense == null)
                MessageBox.Show($"Faild to load License with ID [{internationalLicenseID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ctrlLocalLicenseInfo1.LoadLocalLicense(internationalLicense.GetLocalLicenseID());

            lb_IntLID.Text = internationalLicense.InternationalLicenseID.ToString();
            lb_IssueReason.Text = internationalLicense.IssueType.ToString();
            lb_IssueDate.Text = internationalLicense.IssueDate.ToShortDateString();
            lb_ExpirationDate.Text = internationalLicense.ExpirationDate().ToShortDateString();
            lb_IsActive.Text = internationalLicense.IsActive? "Yes" : "NO";
        }
    }
}
