using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class InternationalLicense
    {
        public int InternationalLicenseID { get; set; }
        public int LocalLicenseID { get; }
        public int LicenseID { get; set; }

        public DateTime ExpirationDate()
        {
            License license = LicenseService.FindByLicenseID(LicenseID);

            return license.IssueDate.AddYears(1);
        }

        public bool IsExpired()
        {
            return DateTime.Today > ExpirationDate();
        }

        public bool IsActive()
        {
            License license = LicenseService.FindByLicenseID(LicenseID);
            return license.IsActive && !IsExpired();
        }

        public InternationalLicense(int localLicenseID, int licenseID)
        {
            LocalLicenseID = localLicenseID;
            LicenseID = licenseID;
        }

        public InternationalLicense(int internationalLicenseID ,int localLicenseID, int licenseID)
            : this(licenseID, licenseID)
        {
            InternationalLicenseID = internationalLicenseID;
        }
    }
}
