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
    }
}