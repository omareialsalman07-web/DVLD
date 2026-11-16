
using System;

namespace DVLD_Business
{
    public class License
    {
        public int LicenseID { get; }
        public enLicenseIssueType IssueTypeID { get; set; }
        public DateTime IssueDate { get; set; }
        public int DriverID { get; set; }
        public int CreatedByUserID { get; set; }

        public License(enLicenseIssueType issueTypeID, DateTime issueDate, 
            int driverID, int createdByUserID)
        {
            IssueTypeID = issueTypeID;
            IssueDate = issueDate;
            DriverID = driverID;
            CreatedByUserID = createdByUserID;
        }

        public License(int licenseID, enLicenseIssueType issueTypeID,
            DateTime issueDate, int driverID, int createdByUserID)
            : this(issueTypeID, issueDate, driverID, createdByUserID)
        {
            LicenseID = licenseID;
        }
    }
}
