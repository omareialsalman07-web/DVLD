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
    public partial class DriverCardFrom : Form
    {
        int _DriverID;
        public DriverCardFrom(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DriverCardFrom_Load(object sender, EventArgs e)
        {
            ctrlDriverInfo1.LoadDriver(_DriverID);
        }
    }
}
