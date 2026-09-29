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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txb_UserName.Text) || string.IsNullOrWhiteSpace(txt_Pass.Text))
            {
                MessageBox.Show("Please fill all the areas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User user = UserService.Find(txb_UserName.Text);
                if(user == null)
                {
                    MessageBox.Show("Can't find User with this user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(!user.Password.Equals(txt_Pass.Text))
                {
                    MessageBox.Show("Wrong password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!user.IsActive)
                {
                    MessageBox.Show("This user is not acitive, contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Form mainForm = new MainForm(user, this);
                mainForm.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
