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
    public partial class UserCardForm : Form
    {
        int UserID;
        public UserCardForm()
        {
            InitializeComponent();
            UserID = -1;
        }
        public UserCardForm(int userID = -1)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void UserCardForm_Load(object sender, EventArgs e)
        {
            if (UserID == -1)
            {
                if (DVLD_Settings.GetCurrnetUser() == null)
                {
                    MessageBox.Show("Can't load user information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ctrlUserCard1.LoadUser(DVLD_Settings.GetCurrnetUser());
            }
            else
            {
                ctrlUserCard1.LoadUser(UserID);
            }
        }
    }
}
