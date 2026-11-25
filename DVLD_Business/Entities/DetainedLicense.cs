
using System;

namespace DVLD_Business
{
    public class DetainedLicense
    {
        public int DetainedLicenseID { get; }
        public int LicenseID { get; }
        public bool IsReleased { get; }
        public DateTime DetainedDate { get; }
        public DateTime? ReleasedDate { get; }
        public User CreatedByUserInfo { get; }
        public User ReleasedByUserInfo { get; }
        public float FineFees { get; }
        public Application ReleaseApplicationInfo { get; }

        public DetainedLicense(int licenseID, bool isReleased, DateTime detainedDate,
            DateTime? releasedDate, int createdByUserID, int? releasedByUserID,
            float fineFees, int? releaseApplicationID)
        {
            LicenseID = licenseID;
            IsReleased = isReleased;
            DetainedDate = detainedDate;
            ReleasedDate = releasedDate;
            CreatedByUserInfo = UserService.FindByUserID(createdByUserID);
            ReleasedByUserInfo = (releasedByUserID != null)? UserService.FindByUserID(releasedByUserID.Value) : null;
            FineFees = fineFees;
            ReleaseApplicationInfo = (releaseApplicationID != null) ? ApplicationService.Find(releaseApplicationID.Value) : null;
        }

        public DetainedLicense(int detainedLicenseID, int licenseID, bool isReleased,
            DateTime detainedDate, DateTime? releasedDate, int createdByUserID,
            int? releasedByUserID, float fineFees, int? releaseApplicationID)
            : this(licenseID, isReleased, detainedDate, releasedDate, createdByUserID,
                  releasedByUserID, fineFees, releaseApplicationID)
        {
            DetainedLicenseID = detainedLicenseID;
        }
    }
}
