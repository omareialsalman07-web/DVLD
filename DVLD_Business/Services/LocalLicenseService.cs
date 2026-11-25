
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace DVLD_Business
{
    public static class LocalLicenseService
    {
        public static LocalLicense Find(int localLicenseID)
        {
            int licenseClassID = -1;

            if (!LocalLicenseData.GetLicenseByLicenseID(localLicenseID, ref licenseClassID))
            {
                return null;
            }

            return LicenseService.FindByLicenseID(localLicenseID) as LocalLicense;
        }



        public static int CreateFirstTime(int localLicenseApplicationID, int createdByUserID)
        {
            LocalLicenseApplication localLicenseApplication = LocalLicenseApplicationService.Find(localLicenseApplicationID);

            if (localLicenseApplication == null)
                throw new InvalidOperationException($"Local license localLicenseApplication [{localLicenseApplicationID}] does not exist.");

            if (localLicenseApplication.ApplicationInfo.Status == enApplicationStatus.eCancelled)
                throw new InvalidOperationException(
                    $"Cannot issue a local license for cancelled localLicenseApplication [{localLicenseApplication.ApplicationInfo.ApplicationID}].");

            if (localLicenseApplication.ApplicationInfo.Status == enApplicationStatus.eCompleted)
                throw new InvalidOperationException($"Application [{localLicenseApplication.ApplicationInfo.ApplicationID}] is already completed.");

            int totalPassedTests = LocalLicenseApplicationService.GetTotalPassedTests(localLicenseApplicationID);

            if (totalPassedTests < 3)
                throw new InvalidOperationException(
                    $"The applicant has only passed {totalPassedTests} out of 3 required tests.");

            // FindByUserID or create the driver.
            Driver driver = DriverService.FindByPersonID(localLicenseApplication.PersonInfo.ID);

            if (driver == null)
            {
                int driverID = DriverService.Create(
                    localLicenseApplication.PersonInfo.ID,
                    createdByUserID);

                if (driverID == -1)
                    throw new InvalidOperationException(
                        "Failed to create driver.");

                driver = DriverService.Find(driverID);
            }

            if (driver == null)
                throw new InvalidOperationException(
                    "Failed to retrieve the newly created driver.");

            // Detain the common license record.
            int licenseID = LicenseService.Create(enLicenseIssueType.eFirstTime, driver.DriverID, localLicenseApplication.ApplicationInfo.ApplicationID, createdByUserID);

            if (licenseID == -1)
                throw new InvalidOperationException(
                    "Failed to create license.");

            // Detain the local license record.
            if (!LocalLicenseData.CreateLocalLicense(licenseID, localLicenseApplication.LicenseClassInfo.LicenseClassID))
                throw new InvalidOperationException(
                    "Failed to create local license.");

            if (!ApplicationService.Complete(localLicenseApplication.ApplicationInfo.ApplicationID))
                throw new InvalidOperationException(
                    "The license was created, but the localLicenseApplication could not be completed.");

            return licenseID;
        }


        private static int _Recreate(int oldLocalLicenseID, int createdByUserID,
            enLicenseIssueType issueType)
        {
            LocalLicense oldLicense = Find(oldLocalLicenseID);

            if (oldLicense == null)
                throw new InvalidOperationException($"Local license [{oldLocalLicenseID}] does not exist.");

            // A renewal is only allowed after expiration.
            if (issueType == enLicenseIssueType.eRenew &&
                !oldLicense.IsExpired())
            {
                throw new InvalidOperationException(
                    $"This license has not expired yet. Expiration date: {oldLicense.ExpirationDate():d}");
            }

            if (!oldLicense.IsActive)
                throw new InvalidOperationException($"Local license [{oldLocalLicenseID}] is not active.");

            int applicationTypeID = (int)enApplicationType.eRenewDrivingLicense;

            ApplicationType applicationType = ApplicationTypeService.Find(applicationTypeID);

            if (applicationType == null)
                throw new InvalidOperationException("Renewal localLicenseApplication type does not exist.");

            int applicationID = ApplicationData.CreateApplication(applicationTypeID, DateTime.Today, (int)enApplicationStatus.eNew,
                applicationType.Fees, createdByUserID);

            if (applicationID == -1)
                throw new InvalidOperationException("Failed to create renewal localLicenseApplication.");

            // Detain the new common license.
            int newLicenseID = LicenseService.Create(
                issueType,
                oldLicense.DriverInfo.DriverID,
                applicationID,
                createdByUserID);

            if (newLicenseID == -1)
                throw new InvalidOperationException(
                    "Failed to create replacement license.");

            // Detain the new local license.
            if (!LocalLicenseData.CreateLocalLicense(newLicenseID, oldLicense.LicenseClass.LicenseClassID))
                throw new InvalidOperationException(
                    "Failed to create the new local license record.");

            // Deactivate the old license only after successful creation.
            if (!LicenseService.DeactivateLicense(oldLicense.LicenseID))
                throw new InvalidOperationException(
                    "Failed to deactivate the previous license.");

            if (!ApplicationService.Complete(applicationID))
                throw new InvalidOperationException(
                    "The new license was created, but the localLicenseApplication could not be completed.");

            return newLicenseID;
        }


        public static int Renew(int oldLocalLicenseID, int createdByUserID)
        {
            return _Recreate(oldLocalLicenseID, createdByUserID, enLicenseIssueType.eRenew);
        }


        public static int ReplacementForLost(int oldLocalLicenseID, int createdByUserID)
        {
            return _Recreate(oldLocalLicenseID, createdByUserID, enLicenseIssueType.eReplacementForLost);
        }


        public static int ReplacementForDamage(int oldLocalLicenseID, int createdByUserID)
        {
            return _Recreate(oldLocalLicenseID, createdByUserID, enLicenseIssueType.eReplacementForDamaged);
        }


        public static bool IsExist(int localLicenseID)
        {
            return LocalLicenseData.isExist(localLicenseID);
        }


        public static List<LocalLicense> GetLocalLicenses()
        {
            List<LocalLicense> licenses = new List<LocalLicense>();

            DataTable data = LocalLicenseData.GetLocalLicenses();

            foreach (DataRow row in data.Rows)
            {
                int localLicenseID =
                    Convert.ToInt32(row["OldLocalLicenseID"]);

                LocalLicense license =
                    Find(localLicenseID);

                if (license != null)
                    licenses.Add(license);
            }

            return licenses;
        }


        public static List<LocalLicense> GetLocalLicensesForDriver(int driverID)
        {
            List<LocalLicense> licenses = new List<LocalLicense>();

            DataTable data =
                LocalLicenseData.GetLocalLicensesForDriver(driverID);

            foreach (DataRow row in data.Rows)
            {
                int localLicenseID =
                    Convert.ToInt32(row["OldLocalLicenseID"]);

                LocalLicense license =
                    Find(localLicenseID);

                if (license != null)
                    licenses.Add(license);
            }

            return licenses;
        }


        public static DataTable GetLocalLicensesForDriver_ForDisplay(int driverID)
        {
            return LocalLicenseData.GetLocalLicensesForDriver_ForDisplay(driverID);
        }
    }
}
