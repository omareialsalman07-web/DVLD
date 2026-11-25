using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlDriverInfo : UserControl
    {
        public ctrlDriverInfo()
        {
            InitializeComponent();
        }

        public void LoadDriver(int DriverID)
        {
            try
            {
                Driver Driver = DriverService.Find(DriverID);
                if (Driver == null)
                {
                    MessageBox.Show($"Error : Can't find driver with ID [{DriverID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                ctrlPersonCard1.LoadPerson(Driver.PersonInfo.ID);

                lbDriverID.Text = Driver.DriverID.ToString();
                lbCreatedByUserName.Text = Driver.CreatedByUserInfo.UserName;
                lbCreatedDate.Text = Driver.CreatedDate.ToShortDateString();
                lbTotalAvailableLicenses.Text = DriverService.GetTotalAvailableLicenses(Driver.DriverID).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
