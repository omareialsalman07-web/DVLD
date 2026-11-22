
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace DVLD_Business
{
    public static class InternationalLicenseService
    {
        private const int RequiredLicenseClassID = 3;

        public static InternationalLicense FindByInternationalID(int internationalLicenseID)
        {
            int licenseID = -1;
            int localLicenseID = -1;

            if (!InternationalLicenseData.GetByInternationalID(
                internationalLicenseID,
                ref licenseID,
                ref localLicenseID))
            {
                return null;
            }

            return LicenseService.FindByLicenseID(licenseID)
                as InternationalLicense;
        }


        public static InternationalLicense FindByLicenseID(int licenseID)
        {
            return LicenseService.FindByLicenseID(licenseID)
                as InternationalLicense;
        }


        public static InternationalLicense FindByLocalLicenseID(
            int localLicenseID)
        {
            int internationalLicenseID = -1;
            int licenseID = -1;

            if (!InternationalLicenseData.GetByLocalLicenseID(
                localLicenseID,
                ref internationalLicenseID,
                ref licenseID))
            {
                return null;
            }

            return LicenseService.FindByLicenseID(licenseID)
                as InternationalLicense;
        }


        public static int CreateFirstTime(int localLicenseID, int createdByUserID)
        {
            LocalLicense localLicense =
                LocalLicenseService.FindByLocalLicenseID(localLicenseID);

            if (localLicense == null)
                throw new InvalidOperationException(
                    $"Local license [{localLicenseID}] does not exist.");

            // Validate the local license class.
            if (localLicense.GetLicenseClassID() != RequiredLicenseClassID)
            {
                LicenseClass requiredClass =
                    LicenseClassService.Find(RequiredLicenseClassID);

                string requiredClassName =
                    requiredClass?.ClassName ?? "Class 3";

                throw new InvalidOperationException(
                    $"International licenses can only be issued to holders of {requiredClassName}.");
            }

            // Validate the local license status.
            if (!localLicense.IsValid())
                throw new InvalidOperationException(
                    "The local license is not active.");

            if (localLicense.IsExpired())
                throw new InvalidOperationException(
                    "The local license has expired.");

            // Check whether an international license already exists.
            if (IsExistByLocalLicenseID(localLicenseID))
            {
                InternationalLicense existingLicense =
                    FindByLocalLicenseID(localLicenseID);

                throw new InvalidOperationException(
                    $"This local license already has an international license [{existingLicense.InternationalLicenseID}].");
            }

            // Detain the application.
            int applicationTypeID =
                (int)enApplicationType.eNewInternationalLicense;

            ApplicationType applicationType =
                ApplicationTypeService.Find(applicationTypeID);

            if (applicationType == null)
                throw new InvalidOperationException(
                    "International license application type does not exist.");

            int applicationID = ApplicationData.CreateApplication(
                applicationTypeID,
                DateTime.Today,
                (int)enApplicationStatus.eNew,
                applicationType.Fees,
                createdByUserID);

            if (applicationID == -1)
                throw new InvalidOperationException(
                    "Failed to create international license application.");

            // Detain the common license record.
            int licenseID = LicenseService.Create(
                enLicenseIssueType.eFirstTime,
                localLicense.DriverID,
                applicationID,
                createdByUserID);

            if (licenseID == -1)
                throw new InvalidOperationException(
                    "Failed to create license.");

            // Detain the international license record.
            int internationalLicenseID =
                InternationalLicenseData.Create(
                    licenseID,
                    localLicense.LocalLicenseID);

            if (internationalLicenseID == -1)
                throw new InvalidOperationException(
                    "Failed to create international license.");

            if (!ApplicationService.Complete(applicationID))
                throw new InvalidOperationException(
                    "The international license was created, but the application could not be completed.");

            return internationalLicenseID;
        }
        private static int Recreate(int oldInternationalLicenseID,
            int createdByUserID, enLicenseIssueType issueType)
        {
            InternationalLicense oldLicense =
                FindByInternationalID(oldInternationalLicenseID);

            if (oldLicense == null)
                throw new InvalidOperationException(
                    $"International license [{oldInternationalLicenseID}] does not exist.");

            if (issueType == enLicenseIssueType.eRenew &&
                !oldLicense.IsExpired())
            {
                throw new InvalidOperationException(
                    $"This license has not expired yet. Expiration date: {oldLicense.ExpirationDate():d}");
            }

            if (!oldLicense.IsActive)
                throw new InvalidOperationException(
                    $"International license [{oldInternationalLicenseID}] is not active.");

            int applicationTypeID =
                (int)enApplicationType.eRenewDrivingLicense;

            ApplicationType applicationType =
                ApplicationTypeService.Find(applicationTypeID);

            if (applicationType == null)
                throw new InvalidOperationException(
                    "Renewal application type does not exist.");

            int applicationID = ApplicationData.CreateApplication(
                applicationTypeID,
                DateTime.Today,
                (int)enApplicationStatus.eNew,
                applicationType.Fees,
                createdByUserID);

            if (applicationID == -1)
                throw new InvalidOperationException(
                    "Failed to create renewal application.");

            // Detain the new common license.
            int newLicenseID = LicenseService.Create(
                issueType,
                oldLicense.DriverID,
                applicationID,
                createdByUserID);

            if (newLicenseID == -1)
                throw new InvalidOperationException("Failed to create replacement license.");

            // Keep the association with the same local license.
            int result = InternationalLicenseData.Create(
                newLicenseID,
                oldLicense.GetLocalLicenseID());

            if (result == -1)
                throw new InvalidOperationException(
                    "Failed to create the new international license.");

            // Deactivate the previous license.
            if (!LicenseService.DeactivateLicense(oldLicense.LicenseID))
                throw new InvalidOperationException(
                    "Failed to deactivate the previous international license.");

            if (!ApplicationService.Complete(applicationID))
                throw new InvalidOperationException(
                    "The new international license was created, but the application could not be completed.");

            return result;
        }


        public static int Renew(int oldInternationalLicenseID, int createdByUserID)
        {
            return Recreate(oldInternationalLicenseID, createdByUserID,
                enLicenseIssueType.eRenew);
        }


        public static int ReplacementForDamage(int oldInternationalLicenseID, int createdByUserID)
        {
            return Recreate(
                oldInternationalLicenseID,
                createdByUserID,
                enLicenseIssueType.eReplacementForDamaged);
        }


        public static int ReplacementForLost(int oldInternationalLicenseID, int createdByUserID)
        {
            return Recreate(oldInternationalLicenseID, createdByUserID,
                enLicenseIssueType.eReplacementForLost);
        }


        public static bool IsExistByLocalLicenseID(int localLicenseID)
        {
            return InternationalLicenseData.IsExistByLocalLicenseID(
                localLicenseID);
        }


        public static bool IsExistByInternationalID(
            int internationalLicenseID)
        {
            return InternationalLicenseData.IsExistByInternationalID(
                internationalLicenseID);
        }


        public static List<InternationalLicense> GetInternationalLicenses()
        {
            List<InternationalLicense> licenses =
                new List<InternationalLicense>();

            DataTable data =
                InternationalLicenseData.GetInternationalLicenses();

            foreach (DataRow row in data.Rows)
            {
                int internationalLicenseID =
                    Convert.ToInt32(row["InternationalLicenseID"]);

                InternationalLicense license =
                    FindByInternationalID(internationalLicenseID);

                if (license != null)
                    licenses.Add(license);
            }

            return licenses;
        }


        public static List<InternationalLicense> GetInternationalLicensesForDriver(
            int driverID)
        {
            List<InternationalLicense> licenses =
                new List<InternationalLicense>();

            DataTable data =
                InternationalLicenseData.GetInternationalLicensesForDriver(
                    driverID);

            foreach (DataRow row in data.Rows)
            {
                int internationalLicenseID =
                    Convert.ToInt32(row["InternationalLicenseID"]);

                InternationalLicense license =
                    FindByInternationalID(internationalLicenseID);

                if (license != null)
                    licenses.Add(license);
            }

            return licenses;
        }


        public static DataTable GetInternationalLicensesForDriver_ForDisplay(
            int driverID)
        {
            return InternationalLicenseData
                .GetInternationalLicensesForDriver_ForDisplay(driverID);
        }
    }
}
