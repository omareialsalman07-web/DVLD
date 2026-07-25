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
    public partial class PersonCardForm : Form
    {
        private int _PersonID = -1;
        public PersonCardForm(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonCardForm_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPerson(_PersonID);
        }
    }
}
