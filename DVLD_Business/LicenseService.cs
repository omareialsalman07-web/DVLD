using DVLD_DataAccess;
using System;

namespace DVLD_Business
{
    public static class LicenseService
    {
        public static License Find(int licenseID)
        {
            int issueTypeID = -1;
            DateTime issueDate = DateTime.MinValue;
            int driverID = -1;
            int createdByUserID = -1;

            if (!LicenseData.GetLicense(licenseID, ref issueTypeID, ref issueDate, ref driverID, ref createdByUserID))
            {
                return null;
            }

            return new License(licenseID, (enLicenseIssueType)issueTypeID,issueDate, driverID, createdByUserID);
        }

        public static int Create(enLicenseIssueType issueTypeID, int driverID, int createdByUserID)
        {
            if (DriverService.Find(driverID) == null)
                throw new InvalidOperationException("Driver does not exist.");

            return LicenseData.CreateLicense((int)issueTypeID, DateTime.Today, driverID, createdByUserID);
        }
    }
}
