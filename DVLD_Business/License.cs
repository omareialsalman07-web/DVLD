
using System;

namespace DVLD_Business
{
    public abstract class License
    {
        public int LicenseID { get; }

        public enLicenseIssueType IssueType { get; }

        public DateTime IssueDate { get; }
        public int DriverID { get; }
        public int ApplicationID { get; }
        public bool IsActive { get; }
        public int CreatedByUserID { get; }

        public abstract DateTime ExpirationDate();
        public bool IsExpired()
        {
            return DateTime.Today > ExpirationDate();
        }

        public bool IsDetained()
        {
            return DetainedLicenseService.IsLicenseDetained(LicenseID);
        }

        public bool IsValid()
        {
            return IsActive && !IsExpired() && !IsDetained();
        }

        protected License(
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID)
        {
            IssueType = issueTypeID;
            IssueDate = issueDate;
            DriverID = driverID;
            ApplicationID = applicationID;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
        }

        protected License(
            int licenseID,
            enLicenseIssueType issueTypeID,
            DateTime issueDate,
            int driverID,
            int applicationID,
            bool isActive,
            int createdByUserID)
            : this(issueTypeID, issueDate, driverID,
                   applicationID, isActive, createdByUserID)
        {
            LicenseID = licenseID;
        }
    }
}
