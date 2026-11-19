
using System;

namespace DVLD_Business
{
    public class LocalLicense : License
    {
        public int LocalLicenseID { get; }

        public LicenseClass LicenseClass { get; }

        public int GetLicenseClassID()
        {
            return LicenseClass.LicenseClassID;
        }

        public override DateTime ExpirationDate ()
        {
            return IssueDate.AddYears(LicenseClass.ValidityLength);
        }


        public LocalLicense(
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID,
            LicenseClass licenseClass)
            : base(issueTypeID, issueDate, driverID,
                   applicationID, isActive, createdByUserID)
        {
            LicenseClass = licenseClass ??
                throw new ArgumentNullException(nameof(licenseClass));
        }


        public LocalLicense(
            int localLicenseID,
            int licenseID,
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID,
            LicenseClass licenseClass)
            : base(licenseID, issueTypeID, issueDate,
                   driverID, applicationID, isActive,
                   createdByUserID)
        {
            LocalLicenseID = localLicenseID;

            LicenseClass = licenseClass ??
                throw new ArgumentNullException(nameof(licenseClass));
        }
    }
}