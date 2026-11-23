
using System;

namespace DVLD_Business
{
    public class InternationalLicense : License
    {
        public LocalLicense LocalLicense { get; }

        public override DateTime ExpirationDate()
        {
            return IssueDate.AddYears(1);
        }

        public InternationalLicense(enLicenseIssueType issueTypeID, DateTime issueDate, int driverID,
            int applicationID, bool isActive, int createdByUserID, int localLicenseID)
            : base(issueTypeID, issueDate, driverID,
                   applicationID, isActive, createdByUserID)
        {
            LocalLicense = LocalLicenseService.FindByLicenseID(localLicenseID);
        }


        public InternationalLicense(
            int licenseID,
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID,
            int localLicenseID)
            : base(licenseID, issueTypeID, issueDate,
                   driverID, applicationID, isActive,
                   createdByUserID)
        {

            LocalLicense = LocalLicenseService.FindByLicenseID(localLicenseID);
        }
    }
}
