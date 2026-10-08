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
    public partial class ManageApplicationTypesForm : Form
    {
        public ManageApplicationTypesForm()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            DataTable dt = null;

            try
            {
                dt = ApplicationTypeService.GetAllApplictionTypes_ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void ManageApplicationTypesForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            Form applicationEditor = new ApplicationTypesEditorForm(ID);
            applicationEditor.ShowDialog();
        }
    }
}
