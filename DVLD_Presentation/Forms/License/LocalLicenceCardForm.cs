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
    public partial class LocalLicenceCardForm : Form
    {
        int _LocalLicenseID;
        public LocalLicenceCardForm(int LocalLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = LocalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LocalLicenceCardForm_Load(object sender, EventArgs e)
        {
            ctrlLocalLicenseInfo1.LoadLocalLicense(_LocalLicenseID);
        }
    }
}
