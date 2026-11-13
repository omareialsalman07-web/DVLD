
using DVLD_DataAccess;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace DVLD_Business
{
    public class TestService
    {
        public static int CreateTest(enTestType testType, int localLicenseApplicationID,
            int createdByUserID)
        {
            enTestType prerequisite = GetPrerequisite(testType);

            if (prerequisite != enTestType.eNone &&
                !TestData.IsPassedTest((int)prerequisite, localLicenseApplicationID))
            {
                throw new InvalidOperationException(
                    $"The {prerequisite} must be passed before taking the {testType}.");
            }

            if (!TestData.CanCreateTest((int)testType, localLicenseApplicationID))
            {
                throw new InvalidOperationException(
                    $"The {testType} has already been passed for this application.");
            }

            var test = new Test(testType, prerequisite, false, null,
                                localLicenseApplicationID, createdByUserID);

            int id = TestData.CreateTest((int)test.TestType, (int)test.PrerequisiteTestType, test.LocalLicenseApplicationID, test.CreatedByUserID);

            if (id == -1)
                throw new InvalidOperationException("The test could not be saved.");

            return id;
        }

        public static Test Find(int testID)
        {
            if (testID <= 0) throw new ArgumentOutOfRangeException(nameof(testID));

            var type = (int)enTestType.eNone;
            var prerequisite = (int)enTestType.eNone;
            bool? result = false;
            string notes = "";
            int llaID = -1, createdBy = -1;

            if (!TestData.GetTestByID(testID, ref type, ref prerequisite, ref result,
                                      ref notes, ref llaID, ref createdBy))
                return null;

            return new Test(testID, (enTestType)type, (enTestType)prerequisite, result, notes, llaID, createdBy);
        }

        // Vision -> Written -> Practical
        public static enTestType GetPrerequisite(enTestType testType)
        {
            switch (testType)
            {
                case enTestType.eWrittenTest: return enTestType.eVisionTest;
                case enTestType.ePracticalTest: return enTestType.eWrittenTest;
                default: return enTestType.eNone;
            }
        }

        public static bool CanCreateTest(enTestType testType, int LLA_ID)
        {
            return TestData.CanCreateTest((int)testType, LLA_ID);
        }

        public static bool IsPassedTest(enTestType TestType, int LLA_ID)
        {
            return TestData.IsPassedTest((int)TestType, LLA_ID);
        }
    }
}
