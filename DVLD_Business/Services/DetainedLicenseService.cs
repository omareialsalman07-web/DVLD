
using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public static class DetainedLicenseService
    {
        public static DetainedLicense Find(int DetainedLicenseID)
        {
            int LicenseID = -1;
            bool IsReleased = false;
            DateTime DetainedDate = DateTime.MinValue;
            DateTime? ReleasedDate = null;
            int CreatedByUserID = -1;
            int? ReleasedByUserID = null;
            float FineFees = 0;
            int? ReleaseApplicationID = null;

            bool IsFound = DetainedLicenseData.GetByDetainedLicenseID(DetainedLicenseID, ref LicenseID, ref IsReleased, ref DetainedDate,
                ref ReleasedDate, ref CreatedByUserID, ref ReleasedByUserID, ref FineFees, ref ReleaseApplicationID);

            if (!IsFound)
                return null;

            return new DetainedLicense(DetainedLicenseID, LicenseID, IsReleased, DetainedDate, ReleasedDate,
                CreatedByUserID, ReleasedByUserID, FineFees, ReleaseApplicationID);
        }

        public static DetainedLicense FindActiveByLicenseID(int LicenseID)
        {
            int DetainedLicenseID = -1;
            bool IsReleased = false;
            DateTime DetainedDate = DateTime.MinValue;
            DateTime? ReleasedDate = null;
            int CreatedByUserID = -1;
            int? ReleasedByUserID = null;
            float FineFees = 0;
            int? ReleaseApplicationID = null;

            bool IsFound = DetainedLicenseData.GetActiveByLicenseID(
                LicenseID, ref DetainedLicenseID, ref IsReleased,
                ref DetainedDate, ref ReleasedDate, ref CreatedByUserID,
                ref ReleasedByUserID, ref FineFees, ref ReleaseApplicationID);

            if (!IsFound)
                return null;

            return new DetainedLicense(DetainedLicenseID, LicenseID, IsReleased, DetainedDate,
                ReleasedDate, CreatedByUserID, ReleasedByUserID, FineFees, ReleaseApplicationID);
        }
        public static int Detain(int LicenseID, float FineFees, int CreatedByUserID)
        {
            License license = LicenseService.FindByLicenseID(LicenseID);
            if (license == null)
                throw new ArgumentOutOfRangeException(nameof(LicenseID));

            if(!license.IsActive)
                throw new Exception("This license is not active.");


            if (FineFees < 0)
                throw new ArgumentOutOfRangeException(nameof(FineFees), "Fine fees cannot be negative.");

            if (IsLicenseDetained(LicenseID))
                throw new InvalidOperationException("This license is already detained.");

            return DetainedLicenseData.Create(
                LicenseID,
                DateTime.Today,
                FineFees,
                CreatedByUserID);
        }

        public static bool Release(int LicenseID, int ReleasedByUserID)
        {
            if (LicenseID <= 0)
                throw new ArgumentOutOfRangeException(nameof(LicenseID));

            if (!UserService.isExistByUserID(ReleasedByUserID))
                throw new ArgumentOutOfRangeException(
                    nameof(ReleasedByUserID),
                    $"The user with ID [{ReleasedByUserID}] does not exist.");

            // Get the active detention record for this license.
            DetainedLicense DetainedLicense = FindActiveByLicenseID(LicenseID);

            if (DetainedLicense == null)
                throw new InvalidOperationException(
                    "This license is not currently detained.");

            // Create the release application.
            int ReleaseApplicationID = ApplicationService.Create(
                enApplicationType.eReleaseDetainedDrivingLicense,
                DateTime.Today,
                enApplicationStatus.eNew,
                ApplicationTypeService.Find(
                    (int)enApplicationType.eReleaseDetainedDrivingLicense).Fees,
                ReleasedByUserID);

            if (ReleaseApplicationID == -1)
                throw new InvalidOperationException(
                    "Can't create a new release detained license application!");

            bool IsReleased = DetainedLicenseData.Release(DetainedLicense.DetainedLicenseID, DateTime.Today, 
                ReleasedByUserID, ReleaseApplicationID);

            if (!IsReleased)
                throw new InvalidOperationException(
                    "Failed to release the detained license.");

            return true;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            if (LicenseID <= 0)
                throw new ArgumentOutOfRangeException(nameof(LicenseID));

            return DetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public static DataTable GetAll()
        {
            return DetainedLicenseData.GetAll();
        }

        public static DataTable GetAllForLicense(int LicenseID)
        {
            if (LicenseID <= 0)
                throw new ArgumentOutOfRangeException(nameof(LicenseID));

            return DetainedLicenseData.GetAllForLicense(LicenseID);
        }

        public static DataTable GetAllForDisplay()
        {
            return DetainedLicenseData.GetAllForDisplay();
        }

        public static DataTable GetAllForDisplayForLicense(int LicenseID)
        {
            if (LicenseID <= 0)
                throw new ArgumentOutOfRangeException(nameof(LicenseID));

            return DetainedLicenseData.GetAllForDisplayForLicense(LicenseID);
        }
    }
}
