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
                lbFees.Text = ApplicationTypeService.Find(application.ApplicationTypeID).Fees.ToString();
                lbType.Text = ApplicationTypeService.Find(application.ApplicationTypeID).Title.ToString();
                lbDate.Text = application.Date.ToString();
                lbCreatedBy.Text = UserService.Find(application.CreatedByUserID).UserName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
