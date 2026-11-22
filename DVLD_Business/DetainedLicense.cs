
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
        public int CreatedByUserID { get; }
        public int? ReleasedByUserID { get; }
        public float FineFees { get; }
        public int? ReleaseApplicationID { get; }

        public DetainedLicense(int licenseID, bool isReleased, DateTime detainedDate,
            DateTime? releasedDate, int createdByUserID, int? releasedByUserID,
            float fineFees, int? releaseApplicationID)
        {
            LicenseID = licenseID;
            IsReleased = isReleased;
            DetainedDate = detainedDate;
            ReleasedDate = releasedDate;
            CreatedByUserID = createdByUserID;
            ReleasedByUserID = releasedByUserID;
            FineFees = fineFees;
            ReleaseApplicationID = releaseApplicationID;
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
