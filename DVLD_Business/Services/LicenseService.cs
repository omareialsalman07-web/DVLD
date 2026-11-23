
using DVLD_DataAccess;
using System;

namespace DVLD_Business
{
    public static class LicenseService
    {
        public static License FindByLicenseID(int licenseID)
        {
            int issueTypeID = -1;
            DateTime issueDate = DateTime.MinValue;
            int driverID = -1;
            int applicationID = -1;
            bool isActive = false;
            int createdByUserID = -1;

            if (!LicenseData.GetLicenseByLicenseID(
                licenseID,
                ref issueTypeID,
                ref issueDate,
                ref driverID,
                ref applicationID,
                ref isActive,
                ref createdByUserID))
            {
                return null;
            }

            // Check whether it is a Local License.
            int localLicenseID = -1;
            int licenseClassID = -1;

            if (LocalLicenseData.GetLicenseByLicenseID(licenseID, ref licenseClassID))
            {
                LicenseClass licenseClass = LicenseClassService.Find(licenseClassID);
                if (licenseClass == null)
                    throw new InvalidOperationException(
                        "The license class associated with this license was not found.");

                return new LocalLicense(licenseID, (enLicenseIssueType)issueTypeID, issueDate,
                    driverID, applicationID, isActive, createdByUserID, licenseClassID);
            }

            // Check whether it is an International License.
            int associatedLocalLicenseID = -1;

            if (InternationalLicenseData.GetByLicenseID(licenseID, ref associatedLocalLicenseID))
            {
                if (!LocalLicenseService.IsExist(associatedLocalLicenseID))
                    throw new InvalidOperationException(
                        "The local license associated with this international license was not found.");

                return new InternationalLicense(licenseID, (enLicenseIssueType)issueTypeID, issueDate, driverID,
                    applicationID, isActive, createdByUserID, associatedLocalLicenseID);
            }

            return null;
        }


        public static License FindByApplicationID(int applicationID)
        {
            int licenseID = -1;
            int issueTypeID = -1;
            DateTime issueDate = DateTime.MinValue;
            int driverID = -1;
            bool isActive = false;
            int createdByUserID = -1;

            if (!LicenseData.GetLicenseByApplicationID(
                applicationID,
                ref licenseID,
                ref issueTypeID,
                ref issueDate,
                ref driverID,
                ref isActive,
                ref createdByUserID))
            {
                return null;
            }

            return FindByLicenseID(licenseID);
        }


        public static int Create(enLicenseIssueType issueType, int driverID,
            int applicationID, int createdByUserID)
        {
            if (DriverService.Find(driverID) == null)
                throw new InvalidOperationException(
                    "Driver does not exist.");

            if (ApplicationService.Find(applicationID) == null)
                throw new InvalidOperationException(
                    "Application does not exist.");

            return LicenseData.CreateLicense((int)issueType, DateTime.Today, driverID,
                applicationID, createdByUserID);
        }


        public static bool DeactivateLicense(int licenseID)
        {
            License license = FindByLicenseID(licenseID);

            if (license == null)
                throw new InvalidOperationException(
                    "License does not exist.");

            if (!license.IsActive)
                return false;

            return LicenseData.DeactivateLicense(licenseID);
        }


        public static bool IsExist(int licenseID)
        {
            return LicenseData.isExist(licenseID);
        }
    }
}
