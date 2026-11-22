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

namespace DVLD_Presentation.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private User _User;
        public ChangePasswordForm()
        {
            InitializeComponent();
            _User = DVLD_Settings.GetCurrnetUser();
        }
        public ChangePasswordForm(User user)
        {
            InitializeComponent();
            _User = user;
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            if (_User == null)
            {
                MessageBox.Show("Can't Load User Information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlUserCard1.LoadUser(_User);
        }

        private void _ProvideError(object sender, string message)
        {
            Control ctrl = (Control)sender;

            ctrl.Focus();
            errorProvider1.SetError(ctrl, message);
        }
        private void _CancleError(object sender)
        {
            Control ctrl = (Control)sender;

            errorProvider1.SetError(ctrl, "");
        } 

        private void txb_CurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txb_CurrentPass.Text))
            {
                _ProvideError(sender, "Current password can't be blank!");
            }
            else if(txb_CurrentPass.Text != DVLD_Settings.GetCurrnetUser().Password)
            {
                _ProvideError(sender, "Current Password Is Incorrenct!");
            }
            else
            {
                _CancleError(sender);
            }
        }

        private void txtNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_CurrentPass.Text))
            {
                _ProvideError(sender, "New password can't be blank!");
            }
            else
            {
                _CancleError(sender);
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_CurrentPass.Text))
            {
                _ProvideError(sender, "Confirm password can't be blank!");
            }
            else if (txtNewPass.Text != txtConfirmPass.Text)
            {
                _ProvideError(sender, "Passwords doesn't match!");
            }
            else
            {
                _CancleError(sender);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_CurrentPass.Text) || string.IsNullOrWhiteSpace(txtNewPass.Text)
                || string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Please fill all the areas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txb_CurrentPass.Text != DVLD_Settings.GetCurrnetUser().Password)
            {
                MessageBox.Show("Current Password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtConfirmPass.Text != txtNewPass.Text)
            {
                MessageBox.Show("Passwords are not matching!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DVLD_Settings.GetCurrnetUser().Password = txtNewPass.Text;
            if (UserService.UpdateUser(DVLD_Settings.GetCurrnetUser()))
            {
                DialogResult dialogResult = MessageBox.Show("Updated Password Successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.OK)
                {
                    txb_CurrentPass.Text = "";
                    txtNewPass.Text = "";
                    txtConfirmPass.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Can't Updated Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
