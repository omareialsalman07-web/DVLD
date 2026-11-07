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
    public partial class ManageLocalLicenseApplicationsForm : Form
    {
        public ManageLocalLicenseApplicationsForm()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseApplications()
        {
            try
            {
                dataGridView1.DataSource = LocalLicenseApplicationService.GetAllLocalLicenseApplicationsForDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageLocalLicenseApplicationsForm_Load(object sender, EventArgs e)
        {
            _LoadLocalLicenseApplications();
        }

        private void cancleApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int LocalLicenseApplicationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["LocalLicenseApplicationID"].Value);
            try
            {
                if (LocalLicenseApplicationService.Cancle(LocalLicenseApplicationID))
                {
                    DialogResult result = MessageBox.Show("Successfully Cancled this Application.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                        _LoadLocalLicenseApplications();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddLocalLicenseApplicationForm addLocalLicenseForm = new AddLocalLicenseApplicationForm();
            addLocalLicenseForm.onAddLocalLicenseApplicationFinish += _LoadLocalLicenseApplications;
            addLocalLicenseForm.ShowDialog();
        }
    }
}
