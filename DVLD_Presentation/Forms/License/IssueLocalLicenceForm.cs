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

namespace DVLD_Presentation.Forms
{
    public partial class IssueLocalLicenceForm : Form
    {
        public delegate void OnIssueLocalLicenceFormFinish();
        public OnIssueLocalLicenceFormFinish onIssueLocalLicenceFormFinish;

        int _LLApplicationID;
        public IssueLocalLicenceForm(int LLApplcationID)
        {
            InitializeComponent();
            _LLApplicationID = LLApplcationID;
        }

        private void IssueLocalLicenceForm_Load(object sender, EventArgs e)
        {
            ctrlLocalLicenseApplicationInfo1.LoadLocalLicenseApplication(_LLApplicationID);

            try
            {
                lb_ClassFees.Text = LicenseClassService.Find(LocalLicenseApplicationService.Find(_LLApplicationID).LicenseClassID).ClassFees.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                int LL_ID = LocalLicenseService.CreateFirstTime(_LLApplicationID, DVLD_Settings.GetCurrnetUser().ID);
                if (LL_ID != -1)
                {
                    MessageBox.Show($"Successfully created Local License with ID [{LL_ID}]", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Field to create Local License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            onIssueLocalLicenceFormFinish?.Invoke();
            this.Close();
        }
    }
}
