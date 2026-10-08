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
    public partial class ManageTestTypesForm : Form
    {
        public ManageTestTypesForm()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            DataTable dt = null;

            try
            {
                dt = TestTypeService.GetAllTestTypes_ToTable();
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

        private void ManageTestTypesForm_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            Form testTypeEditorForm = new TestTypesEditorForm(ID);
            testTypeEditorForm.ShowDialog();
        }
    }
}
