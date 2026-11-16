namespace DVLD_Business
{
    public enum enTestType
    {
        eNone = -1,
        eVisionTest = 1,
        eWrittenTest = 2,
        ePracticalTest = 3
    }

    public enum enApplicationType
    {
        eNewLocalDrivingLicense = 1,
        eRenewDrivingLicense = 2,
        eReplacementForLostDrivingLicense = 3,
        eReplacementForDamagedDrivingLicense = 4,
        eReleaseDetainedDrivingLicense = 5,
        eNewInternationalLicense = 6,
        eRetakeTest = 7
    }

    public enum enApplicationStatus
    {
        eNone = -1,
        eNew = 0,
        eCancelled = 1,
        eCompleted = 2
    }

    public enum enLicenseIssueType
    {
        eFirstTime = 1,
        eRenew = 2,
        eReplacementForDamaged = 3,
        eReplacementForLost = 4
    }
}