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
                LocalLicense localLicense = LocalLicenseService.Find(LocalLicenseID);
                DVLD_Business.License license = LicenseService.Find(localLicense.LicenseID);
                LicenseClass licenseClass = LicenseClassService.Find(localLicense.LicenseClassID);
                Person person = PersonService.Find(DriverService.Find(license.DriverID).PersonID);

                lbName.Text = person.FullName();
                lbClass.Text = licenseClass.ClassName;
                lbLocalLicenseID.Text = localLicense.LicenseClassID.ToString();
                lbNationalNo.Text = person.NationalNo;
                lbGendor.Text = person.Gendor.ToString();
                lbIssueDate.Text = license.IssueDate.Date.ToString();
                lbIssueReason.Text = license.IssueTypeID.ToString();

                lbIsActive.Text = localLicense.IsExpired() ? "Yes" : "No";
                lbDriverID.Text = license.DriverID.ToString();
                lbDOB.Text = person.DateOfBirth.Date.ToString();
                lbIsDetained.Text = "????"; // TODO LATER
                lbExpirationDate.Text = localLicense.ExpirationDate().Date.ToString();

                PersonImage.Image?.Dispose();
                // Load into a temporary image, create a cloned Bitmap, and close the file stream immediately
                using (var tempImg = Image.FromFile(person.ImagePath))
                {
                    PersonImage.Image = new Bitmap(tempImg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
