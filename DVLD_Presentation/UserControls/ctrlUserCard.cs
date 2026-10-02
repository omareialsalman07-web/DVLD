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

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void LoadUser(User user)
        {
            if (user == null)
                return;

            ctrlPersonCard1.LoadPerson(user.PersonID);

            lb_UserID.Text = user.ID.ToString();
            lb_UserName.Text = user.UserName;
            lb_IsActive.Text = user.IsActive.ToString();
        }
    }
}
