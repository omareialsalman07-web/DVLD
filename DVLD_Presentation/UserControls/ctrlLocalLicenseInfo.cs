using DVLD_Business;
using DVLD_Presentation.Properties;
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
    public partial class ctrlLocalLicenseInfo : UserControl
    {
        public ctrlLocalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadLocalLicense(int LocalLicenseID)
        {
            try
            {
                LocalLicense localLicense = LocalLicenseService.Find(LocalLicenseID);;
                Person person = PersonService.Find(DriverService.Find(localLicense.DriverID).PersonID);

                lbName.Text = person.FullName();
                lbClass.Text = localLicense.LicenseClass.ClassName;
                lbLocalLicenseID.Text = localLicense.LicenseID.ToString();
                lbNationalNo.Text = person.NationalNo;
                lbGendor.Text = person.Gendor.ToString();
                lbIssueDate.Text = localLicense.IssueDate.ToShortDateString();
                lbIssueReason.Text = localLicense.IssueType.ToString();

                lbIsActive.Text = localLicense.IsActive? "Yes" : "No";
                lbDriverID.Text = localLicense.DriverID.ToString();
                lbDOB.Text = person.DateOfBirth.ToShortDateString();
                lbIsDetained.Text = localLicense.IsDetained() ? "Yes" : "No";
                lbExpirationDate.Text = localLicense.ExpirationDate().ToShortDateString();

                // Load into a temporary image, create a cloned Bitmap, and close the file stream immediately
                PersonImage.Image?.Dispose();

                if (!string.IsNullOrEmpty(person.ImagePath))
                {
                    using (var tempImg = Image.FromFile(person.ImagePath))
                    {
                        PersonImage.Image = new Bitmap(tempImg);
                    }
                }
                else
                {
                    PersonImage.Image = (person.Gendor == Person.enGendor.Male) ? Resources.Male : Resources.Female;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
