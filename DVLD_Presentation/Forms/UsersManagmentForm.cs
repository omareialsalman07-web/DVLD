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
    public partial class UsersManagmentForm : Form
    {
        public UsersManagmentForm()
        {
            InitializeComponent();
        }

        private void _FillUsersList(DataTable usersTable)
        {
            lst_Users.Items.Clear();

            foreach (DataRow row in usersTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
                item.SubItems.Add(row[3].ToString());
                item.SubItems.Add(row[4].ToString());

                lst_Users.Items.Add(item);
            }
        }

        private void UsersManagmentForm_Load(object sender, EventArgs e)
        {
            cmb_Filter.SelectedIndex = 0;

            try
            {
                _FillUsersList(UserService.GetAllUsersForDisplay());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FillUsersList(UserService.GetAllUsersForDisplay());
            maskedTextBox.Text = "";
            chb_IsActive.Checked = true;

            if(cmb_Filter.SelectedIndex == 0)
            {
                pn_ApplyFilter.Visible = false;
            }
            else if(cmb_Filter.SelectedIndex == 5)
            {
                pn_ApplyFilter.Visible = true;
                chb_IsActive.Visible = true;
                maskedTextBox.Visible = false;
                _FillUsersList(UserService.GetAllUsersForDisplay_Like(UserService.enFilter.IsActive, "1"));
            }
            else
            {
                pn_ApplyFilter.Visible = true;
                maskedTextBox.Visible = true;
                chb_IsActive.Visible = false;
            }
        }

        private void chb_IsActive_CheckedChanged(object sender, EventArgs e)
        {
            char c = (chb_IsActive.Checked == true) ? '1' : '0';
            _FillUsersList(UserService.GetAllUsersForDisplay_Like(UserService.enFilter.IsActive, c.ToString()));
        }

        private void maskedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBox.Text))
            {
                _FillUsersList(UserService.GetAllUsersForDisplay());
                return;
            }

            _FillUsersList(UserService.GetAllUsersForDisplay_Like((UserService.enFilter)cmb_Filter.SelectedIndex, maskedTextBox.Text));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmb_Filter.SelectedIndex = 0;
            maskedTextBox.Text = "";
            _FillUsersList(UserService.GetAllUsersForDisplay());
        }

        Form addEditUser;
        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            addEditUser = new AddEditUser(AddEditUser.enMode.eAdd);
                //addEditUser.MdiParent = this;
            
            addEditUser.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst_Users.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no seleced item to this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int userID = int.Parse(lst_Users.SelectedItems[0].Text);
            Form userCardForm = new UserCardForm(userID);
            userCardForm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form addNewUserForm = new AddEditUser(AddEditUser.enMode.eAdd);
            addNewUserForm.ShowDialog();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst_Users.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no seleced item to this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User userToEdit = UserService.Find(int.Parse(lst_Users.SelectedItems[0].Text));
                Form addNewUserForm = new AddEditUser(AddEditUser.enMode.eEdit, userToEdit);
                addNewUserForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void changePsswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst_Users.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no seleced item to this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User userToEdit = UserService.Find(int.Parse(lst_Users.SelectedItems[0].Text));

                Form changePasswordForm = new ChangePasswordForm(userToEdit);
                changePasswordForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst_Users.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no seleced item to this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if(UserService.DeleteUser(int.Parse(lst_Users.SelectedItems[0].Text)))
                {
                    MessageBox.Show("User was deleted successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Can't delete this user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}