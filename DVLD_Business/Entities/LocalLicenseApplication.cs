using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class LocalLicenseApplication
    {
        public int LocalLicenseApplicationID { get; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public int PersonID { get; set; }

        public LocalLicenseApplication(int ApplicationID, int LicenseClassID, int PersonID)
        {
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.PersonID = PersonID;
        }
        public LocalLicenseApplication(int LocalLicenseApplicationID, int ApplicationID, int LicenseClassID, int PersonID)
            : this(ApplicationID, LicenseClassID, PersonID)
        {
            this.LocalLicenseApplicationID = LocalLicenseApplicationID;
        }
    }
}
