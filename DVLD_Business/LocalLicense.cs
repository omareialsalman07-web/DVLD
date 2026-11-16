using System;
using System.ComponentModel;

namespace DVLD_Business
{
    public class LocalLicense
    {
        public int LocalLicenseID { get; }
        public int LicenseID { get; set; }
        public int LicenseClassID { get; set; }

        public DateTime ExpirationDate()
        {
            License license = LicenseService.FindByLicenseID(LicenseID);
            LicenseClass licenseClass = LicenseClassService.Find(LicenseClassID);

            return license.IssueDate.AddYears(licenseClass.ValidityLength);
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

        public LocalLicense(int licenseID, int licenseClassID)
        {
            LicenseID = licenseID;
            LicenseClassID = licenseClassID;
        }

        public LocalLicense(int localLicenseID, int licenseID, int licenseClassID)
            : this(licenseID, licenseClassID)
        {
            LocalLicenseID = localLicenseID;
        }
    }
}
