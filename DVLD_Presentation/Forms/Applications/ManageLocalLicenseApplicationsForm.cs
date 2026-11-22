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
        private int _SelectedLLA_ID = -1;
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

        private void btn_AddApplication_Click(object sender, EventArgs e)
        {
            AddLocalLicenseApplicationForm addLocalLicenseForm = new AddLocalLicenseApplicationForm();
            addLocalLicenseForm.onAddLocalLicenseApplicationFinish += _LoadLocalLicenseApplications;
            addLocalLicenseForm.ShowDialog();
        }

        private void _RefreshForm()
        {
            _LoadLocalLicenseApplications();
            _UpdateCMP_ManageApplication();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            _RefreshForm();   
        }

        private void _UpdateCMP_ManageApplication()
        {
            visionStToolStripMenuItem.Enabled = !TestService.IsPassedTest(enTestType.eVisionTest, _SelectedLLA_ID)
                &&
                !TestService.IsPassedTest(enTestType.eWrittenTest, _SelectedLLA_ID);
            writtenTestToolStripMenuItem.Enabled = !TestService.IsPassedTest(enTestType.eWrittenTest, _SelectedLLA_ID)
                &&
                TestService.IsPassedTest(enTestType.eVisionTest, _SelectedLLA_ID);
            streetTestToolStripMenuItem.Enabled = !TestService.IsPassedTest(enTestType.ePracticalTest, _SelectedLLA_ID)
                &&
                TestService.IsPassedTest(enTestType.eWrittenTest, _SelectedLLA_ID);

            sToolStripMenuItem.Enabled = !TestService.IsPassedTest(enTestType.ePracticalTest, _SelectedLLA_ID);

            enApplicationStatus status = ApplicationService.Find(LocalLicenseApplicationService.Find(_SelectedLLA_ID).ApplicationID).Status;
            if (status == enApplicationStatus.eNew)
                issueLicenseFirstTimeToolStripMenuItem.Enabled = TestService.IsPassedTest(enTestType.ePracticalTest, _SelectedLLA_ID);
            else
                issueLicenseFirstTimeToolStripMenuItem.Enabled = false;

            if (status == enApplicationStatus.eCompleted)
                showLiToolStripMenuItem.Enabled = true;
            else
                showLiToolStripMenuItem.Enabled = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                _SelectedLLA_ID = -1;
                return;
            }

            _SelectedLLA_ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            _UpdateCMP_ManageApplication();
        }

        private void showApplicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            Form form = new LocalLicenseApplicationCardForm(_SelectedLLA_ID);
            form.ShowDialog();
        }

        private void _SechdualeTest(enTestType testType)
        {
            if (_SelectedLLA_ID == -1)
            {
                MessageBox.Show("Please selected an application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SechdualeTestForm sechdualeTestForm = new SechdualeTestForm(_SelectedLLA_ID, testType);
            sechdualeTestForm.onSechdualeTestFormClose += _RefreshForm;
            sechdualeTestForm.ShowDialog();
        }

        private void visionStToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SechdualeTest(enTestType.eVisionTest);
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SechdualeTest(enTestType.eWrittenTest);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SechdualeTest(enTestType.ePracticalTest);
        }

        private void showLiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedLLA_ID == -1)
            {
                MessageBox.Show("Please selected an application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DVLD_Business.Application Application = ApplicationService.Find(LocalLicenseApplicationService.Find(_SelectedLLA_ID).ApplicationID);
                int LocalLicenseID = LocalLicenseService.FindByLicenseID(LicenseService.FindByApplicationID(Application.ApplicationID).LicenseID).LocalLicenseID;

                Form localLicenseCardForm = new LocalLicenceCardForm(LocalLicenseID);
                localLicenseCardForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void issueLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedLLA_ID == -1)
            {
                MessageBox.Show("Please selected an application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IssueLocalLicenceForm issueLocalLicenceForm = new IssueLocalLicenceForm(_SelectedLLA_ID);
            issueLocalLicenceForm.onIssueLocalLicenceFormFinish += _RefreshForm;
            issueLocalLicenceForm.ShowDialog();
        }
    }
}
