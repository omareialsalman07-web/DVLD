
using System;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class License
    {
        public int LicenseID { get; }
        public enLicenseIssueType IssueTypeID { get; set; }
        public DateTime IssueDate { get; set; }
        public int DriverID { get; set; }
        public int ApplicationID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public License(enLicenseIssueType issueTypeID, DateTime issueDate, 
            int driverID, int applicationID, bool isActive, int createdByUserID)
        {
            IssueTypeID = issueTypeID;
            IssueDate = issueDate;
            DriverID = driverID;
            ApplicationID = applicationID;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
        }

        public License(int licenseID, enLicenseIssueType issueTypeID,
            DateTime issueDate, int driverID, int applicationID, bool isActive, int createdByUserID)
            : this(issueTypeID, issueDate, driverID, applicationID, isActive, createdByUserID)
        {
            LicenseID = licenseID;
        }
    }
}
