using DVLD_Business;
using Microsoft.Win32;
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

namespace DVLD_Presentation.Forms
{
    public partial class TestTypesEditorForm : Form
    {
        int TestTypeID;
        public TestTypesEditorForm(int TestTypeID)
        {
            InitializeComponent();
            this.TestTypeID = TestTypeID;
        }

        private void TestTypesEditorForm_Load(object sender, EventArgs e)
        {
            TestType testType = null;
            try
            {
                testType = TestTypeService.Find(TestTypeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (testType == null)
            {
                MessageBox.Show("Some this went wrong, can't load Test Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            txb_Title.Text = testType.Title;
            txt_Description.Text = testType.Description;
            mtxb_Fees.Text = testType.Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_Title.Text) || 
                string.IsNullOrWhiteSpace(txt_Description.Text) || string.IsNullOrWhiteSpace(mtxb_Fees.Text))
            {
                MessageBox.Show("Please fill all the areas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (TestTypeService.UpdateTestInfo(TestTypeID, txb_Title.Text, txt_Description.Text, Convert.ToSingle(mtxb_Fees.Text)))
                {
                    MessageBox.Show("Updated Application successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("some thing wrong, can't update applcation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
