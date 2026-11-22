using DVLD_Presentation.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class MainForm : Form
    {
        LoginForm loginForm;
        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();

            this.loginForm = loginForm;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        Form peopleManagementForm;
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (peopleManagementForm == null || peopleManagementForm.IsDisposed)
            {
                peopleManagementForm = new PeopleManagementForm();
                peopleManagementForm.MdiParent = this;
            }

            peopleManagementForm.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginForm != null)
                loginForm.Show();

            DVLD_Settings.Logout();
            this.Close();
        }

        private void currenUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form userInfoForm = new UserCardForm();
            userInfoForm.Show();
        }

        private void changePassordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form changePasswordForm = new ChangePasswordForm();
            changePasswordForm.Show();
        }

        Form usersManagementForm;
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usersManagementForm == null || usersManagementForm.IsDisposed)
            {
                usersManagementForm = new UsersManagmentForm();
                usersManagementForm.MdiParent = this;
            }

            usersManagementForm.Show();
        }

        Form ManageApplicationTypesForm;
        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManageApplicationTypesForm == null || ManageApplicationTypesForm.IsDisposed)
            {
                ManageApplicationTypesForm = new ManageApplicationTypesForm();
                ManageApplicationTypesForm.MdiParent = this;
            }

            ManageApplicationTypesForm.Show();
        }

        Form ManageTestTypesForm;
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManageTestTypesForm == null || ManageTestTypesForm.IsDisposed)
            {
                ManageTestTypesForm = new ManageTestTypesForm();
                ManageTestTypesForm.MdiParent = this;
            }

            ManageTestTypesForm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close();
        }

        private void locaLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addLocalLicenseForm = new AddLocalLicenseApplicationForm();
            addLocalLicenseForm.ShowDialog();
        }

        Form ManageLocalLicenseApplicationsForm;
        private void localLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManageLocalLicenseApplicationsForm == null || ManageLocalLicenseApplicationsForm.IsDisposed)
            {
                ManageLocalLicenseApplicationsForm = new ManageLocalLicenseApplicationsForm();
                ManageLocalLicenseApplicationsForm.MdiParent = this;
            }

            ManageLocalLicenseApplicationsForm.Show();
        }

        Form DriversForm;
        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DriversForm == null || DriversForm.IsDisposed)
            {
                DriversForm = new ManageDriversForm();
                DriversForm.MdiParent = this;
            }

            DriversForm.Show();
        }

        private void internationalLicnseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new IssueInternationalLicenseForm();
            form.ShowDialog();
        }

        Form manageIntlLicensesForm;
        private void internationalApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manageIntlLicensesForm == null || manageIntlLicensesForm.IsDisposed)
            {
                manageIntlLicensesForm = new ManageIntlLicensesForm();
                manageIntlLicensesForm.MdiParent = this;
            }

            manageIntlLicensesForm.Show();
        }

        private void replacementForLostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new RenewLicenseForm();
            form.ShowDialog();
        }

        private void replacmentForDamageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ReplacementForLostorDamagedLicenseForm();
            form.ShowDialog();
        }

        private void releseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new DetainedReleasedForm(DetainedReleasedForm.enMode.eRelease);
            form.ShowDialog();
        }

        private void detainDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new DetainedReleasedForm(DetainedReleasedForm.enMode.eDetain);
            form.ShowDialog();
        }

        private void releaseDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new DetainedReleasedForm(DetainedReleasedForm.enMode.eRelease);
            form.ShowDialog();
        }

        private void manageDetinedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ManageDetainedLiceses();
            form.ShowDialog();
        }
    }
}