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
    public partial class ApplicationTypesEditorForm : Form
    {
        int ApplicationTypeID;
        public ApplicationTypesEditorForm(int ApplicationTypeID)
        {
            InitializeComponent();
            this.ApplicationTypeID = ApplicationTypeID;
        }

        private void ApplicationTypesEditorForm_Load(object sender, EventArgs e)
        {
            ApplicationType applicationType = null;
            try
            {
                applicationType = ApplicationTypeService.Find(ApplicationTypeID);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if(applicationType == null)
            {
                MessageBox.Show("Some this went wrong, can't load application type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            txb_Title.Text = applicationType.Title;
            mtxb_Fees.Text = applicationType.Fees.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txb_Title.Text) || string.IsNullOrWhiteSpace(mtxb_Fees.Text))
            {
                MessageBox.Show("Please fill all the areas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if(ApplicationTypeService.UpdateApplicationInfo(ApplicationTypeID, txb_Title.Text, Convert.ToSingle(mtxb_Fees.Text)))
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
