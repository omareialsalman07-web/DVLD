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
    public partial class LicensesHistoryForm : Form
    {
        int _DriverID;
        public LicensesHistoryForm(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
        }

        private void LicensesHistoryForm_Load(object sender, EventArgs e)
        {
            ctrlDriverInfo1.LoadDriver(_DriverID);

            try
            {
                dataGridView_Local.DataSource = LocalLicenseService.GetLocalLicensesForDriver_ForDisplay(_DriverID);
                dataGridView_International.DataSource = InternationalLicenseService.GetInternationalLicensesForDriver_ForDisplay(_DriverID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
