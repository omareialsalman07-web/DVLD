
using System;

namespace DVLD_Business
{
    public class LocalLicense : License
    {
        public LicenseClass LicenseClass { get; }

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
            int licenseClassID)
            : base(issueTypeID, issueDate, driverID,
                   applicationID, isActive, createdByUserID)
        {
            LicenseClass = LicenseClassService.Find(licenseClassID);
        }


        public LocalLicense(
            int licenseID,
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID,
            int licenseClassID)
            : base(licenseID, issueTypeID, issueDate,
                   driverID, applicationID, isActive,
                   createdByUserID)
        {
            LicenseClass = LicenseClassService.Find(licenseClassID);
        }
    }
}