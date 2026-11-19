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
    public partial class IntLicenseCardForm : Form
    {
        int _IntLiceseID = -1;
        public IntLicenseCardForm(int InternationalLicenseID)
        {
            InitializeComponent();
            _IntLiceseID = InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IntLicenseCardForm_Load(object sender, EventArgs e)
        {
            if(_IntLiceseID == -1)
            {
                MessageBox.Show("Invalid License ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ctrlInternationalLicenseInfo1.LoadInternaitonalLicense(_IntLiceseID);
        }
    }
}
