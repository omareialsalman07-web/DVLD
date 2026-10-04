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
        public enum enMode { eAdd, eEdit };
        enMode Mode;
        User _User;
        int PersonID = -1;
        public AddEditUser(enMode Mode, User user = null)
        {
            InitializeComponent();

            this.Mode = Mode;
            _User = user;
        }

        void _RestForm()
        {
            if(Mode == enMode.eEdit)
            {
                if (_User == null)
                    return;

                PersonID = _User.PersonID;

                txb_Pass.Enabled = false;
                txb_ConfirmPass.Enabled = false;

                ctrlPersonCard1.LoadPerson(_User.PersonID);

                lb_UserID.Text = _User.ID.ToString();
                txb_UserName.Text = _User.UserName;
                txb_Pass.Text = _User.Password;
                txb_ConfirmPass.Text = _User.Password;
                chb_IsActive.Checked = _User.IsActive;
                Label.Text = "Update User";
                Label.ForeColor = Color.Red;
            }
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            comboBox.SelectedIndex = 0;
            _RestForm();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox.Text))
            {
                //textBox.Focus();
                errorProvider1.SetError(textBox, "This text box can't be blank!");
                return;
            }

            bool exists;
            if (comboBox.SelectedIndex == 0)
            {
                exists = PersonService.isExist(Convert.ToInt32(textBox.Text));
            }
            else
            {
                exists = PersonService.isExist(textBox.Text);
            }

            if (!exists)
            {
                //textBox.Focus();
                errorProvider1.SetError(textBox, "No matching person was found.");
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            } 
        }

        private void bnt_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return;

            Person person = (comboBox.SelectedIndex == 0) ? PersonService.Find(Convert.ToInt32(textBox.Text))
                : PersonService.Find(textBox.Text);

            if (person == null)
                return;

            ctrlPersonCard1.LoadPerson(person);
            PersonID = person.ID;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (PersonID != -1)
            {
                tabControl.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Please select a vailed person!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            else if(UserService.isExist(txb_UserName.Text) && Mode == enMode.eAdd)
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
            if (UserService.isExist(txb_UserName.Text) && Mode == enMode.eAdd)
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
            User user = new User(PersonID, txb_UserName.Text, txb_Pass.Text, chb_IsActive.Checked);
            int id = UserService.AddNewUser(user);

            if (id != -1)
            {
                //lb_UserID.Text = id.ToString();

                DialogResult dialog = MessageBox.Show("User addes successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    Mode = enMode.eEdit;
                    _User = new User(id, PersonID, user.UserName, user.Password, user.IsActive);
                    _RestForm();
                }
            }
        }

        private void _Update()
        {
            if(_User == null)
            {
                MessageBox.Show("We can't load the user to update it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserName = txb_UserName.Text;
            _User.IsActive = chb_IsActive.Checked;
            _User.PersonID = PersonID;
            if(UserService.UpdateUser(_User))
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

            if (!isInputValaid())
            {
                return;
            }

            if (Mode == enMode.eAdd)
                _AddNew();
            else
                _Update();

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _OnCreatePersonFinshed(int personID)
        {

            ctrlPersonCard1.LoadPerson(personID);
            PersonID = personID;
        }

        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonForm addNewPersonForm = new AddEditPersonForm(AddEditPersonForm.enMode.eAddNew);
            addNewPersonForm.onCreatePersonFinish += _OnCreatePersonFinshed;
            addNewPersonForm.ShowDialog();
        }
    }
}
