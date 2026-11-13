using System;

namespace DVLD_Business
{
    public class Test
    {
        public int TestID { get; }
        public enTestType TestType { get; }
        public enTestType PrerequisiteTestType { get; }
        public bool? Result { get; }
        public string Notes { get; }
        public int LocalLicenseApplicationID { get; }
        public int CreatedByUserID { get; }

        public Test(enTestType testType, enTestType prerequisiteTestType,
                    bool? result, string notes, int localLicenseApplicationID, int createdByUserID)
        {
            if (testType == enTestType.eNone)
                throw new ArgumentException("A valid test type is required.", nameof(testType));

            if (localLicenseApplicationID <= 0)
                throw new ArgumentOutOfRangeException(nameof(localLicenseApplicationID));

            if (createdByUserID <= 0)
                throw new ArgumentOutOfRangeException(nameof(createdByUserID));

            TestType = testType;
            PrerequisiteTestType = prerequisiteTestType;
            Result = result;
            Notes = notes ?? string.Empty;
            LocalLicenseApplicationID = localLicenseApplicationID;
            CreatedByUserID = createdByUserID;
        }

        public Test(int testID, enTestType testType, enTestType prerequisiteTestType,
                    bool? result, string notes, int localLicenseApplicationID, int createdByUserID)
            : this(testType, prerequisiteTestType, result, notes, localLicenseApplicationID, createdByUserID)
        {
            TestID = testID;
        }
    }
}