using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlBasicApplicationInfo : UserControl
    {
        public ctrlBasicApplicationInfo()
        {
            InitializeComponent();
        }

        private void ctrlBasicApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadApplication(int ApplicationID)
        {
            try
            {
                DVLD_Business.Application application = ApplicationService.Find(ApplicationID);

                lb_ID.Text = application.ApplicationID.ToString();
                lbStatus.Text = application.Status.ToString();
                lbFees.Text = ApplicationTypeService.Find((int)application.Type).Fees.ToString();
                lbType.Text = ApplicationTypeService.Find((int)application.Type).Title.ToString();
                lbDate.Text = application.Date.ToString();
                lbCreatedBy.Text = UserService.Find(application.CreatedByUserID).UserName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadLockupApplication(enApplicationType applicationType)
        {
            try
            {
                lb_ID.Text = "N/A";
                lbStatus.Text = "New";
                lbFees.Text = ApplicationTypeService.Find((int)applicationType).Fees.ToString();
                lbType.Text = ApplicationTypeService.Find((int)applicationType).Title.ToString();
                lbDate.Text = DateTime.Today.ToShortDateString();
                lbCreatedBy.Text = DVLD_Settings.GetCurrnetUser().UserName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
