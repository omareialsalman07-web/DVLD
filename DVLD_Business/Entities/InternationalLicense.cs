
using System;

namespace DVLD_Business
{
    public class InternationalLicense : License
    {
        public int InternationalLicenseID { get; }

        public LocalLicense LocalLicense { get; }

        public int GetLocalLicenseID()
        {
            return LocalLicense.LocalLicenseID;
        }
        public override DateTime ExpirationDate()
        {
            return IssueDate.AddYears(1);
        }

        public InternationalLicense(
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID,
            LocalLicense localLicense)
            : base(issueTypeID, issueDate, driverID,
                   applicationID, isActive, createdByUserID)
        {
            LocalLicense = localLicense ??
                throw new ArgumentNullException(nameof(localLicense));
        }


        public InternationalLicense(
            int internationalLicenseID,
            int licenseID,
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID,
            LocalLicense localLicense)
            : base(licenseID, issueTypeID, issueDate,
                   driverID, applicationID, isActive,
                   createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;

            LocalLicense = localLicense ??
                throw new ArgumentNullException(nameof(localLicense));
        }
    }
}
