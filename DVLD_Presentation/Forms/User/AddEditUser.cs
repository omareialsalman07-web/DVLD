using DVLD_Business;
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

namespace DVLD_Presentation
{
    public partial class AddEditUser : Form
    {
        public delegate void On_Create_Update_UserFinsh(int UserID);
        public enum enMode { eAdd, eEdit };

        public On_Create_Update_UserFinsh on_Create_Update_UserFinsh;
        enMode Mode;
        int _UserID;
        public AddEditUser(enMode Mode, int userID = -1)
        {
            InitializeComponent();

            this.Mode = Mode;
            _UserID = userID;
        }

        void _RestForm()
        {
            if(Mode == enMode.eEdit)
            {
                User user = UserService.FindByUserID(_UserID);
                if (user == null)
                    return;

                ctrlUserSelecter1.SetSelected_PersonID(user.PersonInfo.ID);

                txb_Pass.Enabled = false;
                txb_ConfirmPass.Enabled = false;

                lb_UserID.Text = user.ID.ToString();
                txb_UserName.Text = user.UserName;
                txb_Pass.Text = user.Password;
                txb_ConfirmPass.Text = user.Password;
                chb_IsActive.Checked = user.IsActive;
                Label.Text = "Update User";
                Label.ForeColor = Color.Red;
            }
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            _RestForm();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void txb_UserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txb_UserName.Text))
            {
                errorProvider1.SetError(txb_UserName, "This can't be blank!");
            }
            else if(UserService.isExistByUserName(txb_UserName.Text) && Mode == enMode.eAdd)
            {
                errorProvider1.SetError(txb_UserName, "This user name already used!");
            }
            else
            {
                errorProvider1.SetError(txb_UserName, "");
            }

        }

        private void txb_Pass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_Pass.Text))
            {
                errorProvider1.SetError(txb_Pass, "This can't be blank!");
            }
            else
            {
                errorProvider1.SetError(txb_Pass, "");
            }
        }

        private void txb_ConfirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_ConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_ConfirmPass.Text))
            {
                errorProvider1.SetError(txb_ConfirmPass, "This can't be blank!");
            }
            else if (txb_ConfirmPass.Text != txb_ConfirmPass.Text)
            {
                errorProvider1.SetError(txb_ConfirmPass, "Passwords are not mahched!");
            }
            else
            {
                errorProvider1.SetError(txb_ConfirmPass, "");
            }
        }

        private bool isInputValaid()
        {
            if (string.IsNullOrWhiteSpace(txb_UserName.Text) || string.IsNullOrWhiteSpace(txb_Pass.Text)
                || string.IsNullOrWhiteSpace(txb_ConfirmPass.Text))
            {
                MessageBox.Show("Please fill all the areas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (UserService.isExistByUserName(txb_UserName.Text) && Mode == enMode.eAdd)
            {
                MessageBox.Show("This user name already used!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!txb_Pass.Text.Equals(txb_ConfirmPass.Text))
            {
                MessageBox.Show("Passwords doesn't matches!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void _AddNew()
        {
            User user = new User(ctrlUserSelecter1.GetSelected_PersonID(), txb_UserName.Text, txb_Pass.Text, chb_IsActive.Checked);
            int id = UserService.AddNewUser(user);

            if (id != -1)
            {
                //lb_UserID.Text = id.ToString();

                DialogResult dialog = MessageBox.Show("User addes successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    Mode = enMode.eEdit;
                    _UserID = id;
                    _RestForm();
                }
            }
        }

        private void _Update()
        {
            if(!UserService.isExistByUserID(_UserID))
            {
                MessageBox.Show("We can't load the user to update it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = new User(_UserID, ctrlUserSelecter1.GetSelected_PersonID(), txb_UserName.Text, txb_Pass.Text, chb_IsActive.Checked);
            if(UserService.UpdateUser(user))
            {
                MessageBox.Show("We updated user successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("We can't update this user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isInputValaid())
                {
                    return;
                }

                if (Mode == enMode.eAdd)
                    _AddNew();
                else
                    _Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (ctrlUserSelecter1.IsPersonSelected())
                tabControl.SelectedIndex = 1;
        }

        private void AddEditUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_UserID == -1)
                return;

            on_Create_Update_UserFinsh?.Invoke(_UserID);
        }
    }
}
