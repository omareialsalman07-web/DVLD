using DVLD_DataAccess;
using System;
using System.Threading;

namespace DVLD_Business
{
    public static class LicenseService
    {
        public static License Find(int licenseID)
        {
            int issueTypeID = -1;
            DateTime issueDate = DateTime.MinValue;
            int driverID = -1;
            int applicationID = -1;
            bool isActive = false;
            int createdByUserID = -1;

            if (!LicenseData.GetLicense(licenseID, ref issueTypeID, ref issueDate, ref driverID, ref applicationID, ref isActive, ref createdByUserID))
            {
                return null;
            }

            return new License(licenseID, (enLicenseIssueType)issueTypeID,issueDate, driverID, applicationID, isActive, createdByUserID);
        }

        public static int Create(enLicenseIssueType issueType, int driverID, int applicationID, int createdByUserID)
        {
            if (DriverService.Find(driverID) == null)
                throw new InvalidOperationException("Driver does not exist.");

            return LicenseData.CreateLicense((int)issueType, DateTime.Today, driverID, applicationID, createdByUserID);
        }
    }
}
