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
    public partial class AddLocalLicenseApplicationForm : Form
    {
        public delegate void OnAddLocalLicenseApplicationFinish();
        public OnAddLocalLicenseApplicationFinish onAddLocalLicenseApplicationFinish;

        public AddLocalLicenseApplicationForm()
        {
            InitializeComponent();
        }

        private void _LoadLicenseClasses()
        {
            try
            {
                DataTable dt = LicenseClassService.GetAllLicenseClasses();

                cbLicenseClasses.DataSource = dt;
                cbLicenseClasses.DisplayMember = "ClassName"; // The column name you want to show in the dropdown
                cbLicenseClasses.ValueMember = "LicenseClassID";   // The underlying column name for the ID
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddLocalLicenseApplicationForm_Load(object sender, EventArgs e)
        {
            _LoadLicenseClasses();
            cbLicenseClasses.SelectedIndex = 2;

            lb_ApplicationDate.Text = DateTime.Today.ToShortDateString();
            lb_Fees.Text = ApplicationTypeService.Find((int)TestType.enApplicationType.eNewInternationalLicense).Fees.ToString();
            lb_CreatedBy.Text = DVLD_Settings.GetCurrnetUser().UserName;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if(!ctrlPersonSelecter1.IsPersonSelected())
                {
                    MessageBox.Show("Please Select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (LocalLicenseApplicationService.Create(Convert.ToInt32(cbLicenseClasses.SelectedValue), ctrlPersonSelecter1.GetSelected_PersonID(), DVLD_Settings.GetCurrnetUser().ID))
                {
                    DialogResult result = MessageBox.Show("Successfully Added New Application", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        onAddLocalLicenseApplicationFinish?.Invoke();
                        this.Dispose();
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
