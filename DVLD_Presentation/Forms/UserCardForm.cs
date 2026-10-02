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
        User _User;
        public UserCardForm(User user)
        {
            InitializeComponent();
            _User = user;
        }

        private void UserCardForm_Load(object sender, EventArgs e)
        {
            if(_User == null)
            {
                MessageBox.Show("Can't load user information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlUserCard1.LoadUser(_User);
        }
    }
}
