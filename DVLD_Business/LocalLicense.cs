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
            License license = LicenseService.Find(LicenseID);
            LicenseClass licenseClass = LicenseClassService.Find(LicenseClassID);

            return license.IssueDate.AddYears(licenseClass.ValidityLength);
        }

        public bool IsExpired()
        {
            return DateTime.Today > ExpirationDate();
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
