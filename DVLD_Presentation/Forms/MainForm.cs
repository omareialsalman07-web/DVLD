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
        private User CurrnetUser;
        LoginForm loginForm;
        public MainForm(User currnetUser, LoginForm loginForm)
        {
            InitializeComponent();

            CurrnetUser = currnetUser;
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
            peopleManagementForm.BringToFront();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginForm != null)
                loginForm.Show();

            this.Close();
        }
    }
}
