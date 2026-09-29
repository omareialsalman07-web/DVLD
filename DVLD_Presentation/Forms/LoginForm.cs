using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace DVLD_Presentation.Forms
{
    public partial class LoginForm : Form
    {
        string Path;

        public LoginForm()
        {
            InitializeComponent();

            btnHidePass.Visible = false;

            Path = System.IO.Path.Combine(DVLD_Settings.GetLocalDataPath(), "loginData.txt");

            _LoadLoginData();
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

                _SaveLoginData();

                Form mainForm = new MainForm(user, this);
                mainForm.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _LoadLoginData()
        {
            if (!File.Exists(Path))
                return;

                string dataLine = File.ReadAllText(Path);

            string[] vData = dataLine.Split(new[] { "//#//" }, StringSplitOptions.RemoveEmptyEntries);
            if (vData.Length < 0)
                return;

            chb_rememberMe.Checked = (vData[0] == "T");

            if(vData.Length > 1)
            {
                txb_UserName.Text = vData[1];
                txt_Pass.Text = vData[2];
            }
        }

        private void _SaveLoginData()
        {
            if (chb_rememberMe.Checked)
            {
                string line = $"T//#//{txb_UserName.Text}//#//{txt_Pass.Text}";
                File.WriteAllText(Path, line);
            }
            else
            {
                File.WriteAllText(Path, "F");
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            txt_Pass.UseSystemPasswordChar = false;
            btnHidePass.Visible = true;
            btnShowPass.Visible = false;

        }

        private void btnHidePass_Click(object sender, EventArgs e)
        {
            txt_Pass.UseSystemPasswordChar = true;
            btnShowPass.Visible = true;
            btnHidePass.Visible = false;
        }
    }
}
