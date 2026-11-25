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
        public Application ApplicationInfo { get; set; }
        public LicenseClass LicenseClassInfo { get; set; }
        public Person PersonInfo { get; set; }

        public LocalLicenseApplication(int ApplicationID, int LicenseClassID, int PersonID)
        {
            this.ApplicationInfo = ApplicationService.Find(ApplicationID);
            this.LicenseClassInfo = LicenseClassService.Find(LicenseClassID);
            this.PersonInfo = PersonService.Find(PersonID);
        }
        public LocalLicenseApplication(int LocalLicenseApplicationID, int ApplicationID, int LicenseClassID, int PersonID)
            : this(ApplicationID, LicenseClassID, PersonID)
        {
            this.LocalLicenseApplicationID = LocalLicenseApplicationID;
        }
    }
}
