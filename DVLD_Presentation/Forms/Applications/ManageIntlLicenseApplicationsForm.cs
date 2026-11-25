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
    public partial class ManageIntlLicenseApplicationsForm : Form
    {
        private int _SelectedDriverID = -1;
        private int _SelectedInternationalLicenseID = -1;

        public ManageIntlLicenseApplicationsForm()
        {
            InitializeComponent();
        }

        private void ManageIntlLicensesForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ApplicationService.GetNewIntlLicenseApps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                _SelectedDriverID = -1;
                return;
            }

            _SelectedDriverID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DriverInfo"].Value);
            _SelectedInternationalLicenseID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["LicenseID"].Value);
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedDriverID == -1)
            {
                MessageBox.Show("Please select a Driver!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form licensesHistoryForm = new LicensesHistoryForm(_SelectedDriverID);
            licensesHistoryForm.ShowDialog();
        }

        private void showDrvierInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedDriverID == -1)
            {
                MessageBox.Show("Please select a Driver!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form driverCardForm = new DriverCardFrom(_SelectedDriverID);
            driverCardForm.ShowDialog();
        }
    }
}
