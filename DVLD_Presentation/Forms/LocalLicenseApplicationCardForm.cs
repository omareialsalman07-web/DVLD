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
    public partial class LocalLicenseApplicationCardForm : Form
    {
        private int _LocalLicenseApplication = -1;
        public LocalLicenseApplicationCardForm(int LocalLicenseApplication)
        {
            InitializeComponent();
            _LocalLicenseApplication = LocalLicenseApplication;
        }

        private void LocalLicenseApplicationCardForm_Load(object sender, EventArgs e)
        {
            ctrlLocalLicenseApplicationInfo1.LoadLocalLicenseApplication(_LocalLicenseApplication);
        }
    }
}
