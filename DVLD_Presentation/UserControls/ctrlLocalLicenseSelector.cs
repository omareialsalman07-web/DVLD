using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlLocalLicenseSelector : UserControl
    {
        public delegate void OnSelectLicense(bool isValid);
        public OnSelectLicense onSelectLicense;
        
        public int SelectedLocalLicenseID { get; private set; }

        public ctrlLocalLicenseSelector()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txb_LicenseID.Text))
                    return;

                int LL_ID = Convert.ToInt32(txb_LicenseID.Text);
                LocalLicense localLicense = LocalLicenseService.FindByLocalLicenseID(LL_ID);

                if (localLicense == null)
                {
                    MessageBox.Show($"Can't Local License with ID [{LL_ID}]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(!localLicense.IsActive())
                {
                    MessageBox.Show($"The Local License with ID [{LL_ID}] should be active!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctrlLocalLicenseInfo1.Enabled = false;
                    onSelectLicense?.Invoke(false);
                    SelectedLocalLicenseID = -1;
                    return;
                }

                ctrlLocalLicenseInfo1.Enabled = true;
                onSelectLicense?.Invoke(true);
                ctrlLocalLicenseInfo1.LoadLocalLicense(LL_ID);
                SelectedLocalLicenseID = LL_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlLocalLicenseSelector_Load(object sender, EventArgs e)
        {

        }
    }
}
