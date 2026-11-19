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

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form;
            if (tabControl1.SelectedIndex == 0) // Local
            {
                if (dataGridView_Local.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select a license!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ID = (int)dataGridView_Local.SelectedRows[0].Cells[0].Value;
                form = new LocalLicenceCardForm(ID);
            }
            else
            {
                if (dataGridView_International.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select a license!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ID = (int)dataGridView_International.SelectedRows[0].Cells[0].Value;
                form = new IntLicenseCardForm(ID);
            }
            form.ShowDialog();
        }
    }
}
