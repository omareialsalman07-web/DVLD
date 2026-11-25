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
    public partial class ManageDetainedLiceses : Form
    {
        private int _SelectedDriverID = -1;
        private int _SelectedLicenseID = -1;

        public ManageDetainedLiceses()
        {
            InitializeComponent();
        }

        private void _RefreshForm()
        {
            try
            {
                dataGridView1.DataSource = DetainedLicenseService.GetAllForDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageDetainedLiceses_Load(object sender, EventArgs e)
        {
            _RefreshForm();   
        }
        private void showDriverInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedDriverID == -1)
            {
                MessageBox.Show("Please select a License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form driverCardForm = new DriverCardFrom(_SelectedDriverID);
            driverCardForm.ShowDialog();
        }
        private void showLicesneHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedDriverID == -1)
            {
                MessageBox.Show("Please select a License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form licensesHistoryForm = new LicensesHistoryForm(_SelectedDriverID);
            licensesHistoryForm.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                _SelectedDriverID = -1;
                _SelectedLicenseID = -1;
                return;
            }

            _SelectedLicenseID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["LicenseID"].Value);
            _SelectedDriverID = LicenseService.FindByLicenseID(_SelectedLicenseID).DriverInfo.DriverID;
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedLicenseID == -1)
            {
                MessageBox.Show("Please select a License!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (DetainedLicenseService.Release(_SelectedLicenseID, DVLD_Settings.GetCurrnetUser().ID))
                {
                    MessageBox.Show($"Successfully Released License with ID [{_SelectedLicenseID}]!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshForm();
                }
                else
                    MessageBox.Show($"un able to Release License with ID [{_SelectedLicenseID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Release(object sender, EventArgs e)
        {
            DetaineReleaseLicenseForm form = new DetaineReleaseLicenseForm(DetaineReleaseLicenseForm.enMode.eRelease);
            form.onDetaineReleaseLicenseFormClose += _RefreshForm;
            form.ShowDialog();
        }

        private void btnDetained(object sender, EventArgs e)
        {
            DetaineReleaseLicenseForm form = new DetaineReleaseLicenseForm(DetaineReleaseLicenseForm.enMode.eDetain);
            form.onDetaineReleaseLicenseFormClose += _RefreshForm;
            form.ShowDialog();
        }
    }
}
