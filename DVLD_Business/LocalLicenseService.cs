
using DVLD_DataAccess;
using System;

namespace DVLD_Business
{
    public static class LocalLicenseService
    {
        public static LocalLicense Find(int localLicenseID)
        {
            int licenseID = -1;
            int licenseClassID = -1;

            if (!LocalLicenseData.GetLicense(localLicenseID, ref licenseID, ref licenseClassID))
            {
                return null;
            }

            return new LocalLicense(localLicenseID, licenseID, licenseClassID);
        }

        public static int Create(int LocalLicenseApplicationID, enLicenseIssueType issueTypeID, int createdByUserID)
        {
            LocalLicenseApplication localLicenseApplication = LocalLicenseApplicationService.Find(LocalLicenseApplicationID);
            if (localLicenseApplication == null)
                throw new Exception($"Failed to find Local License Application with ID [{LocalLicenseApplicationID}].");

            if(ApplicationService.Find(localLicenseApplication.ApplicationID).Status == enApplicationStatus.eCancelled)
                throw new Exception($"Failed to Issue Local License in canceled Application with ID [{localLicenseApplication.ApplicationID}].");
            
            if(ApplicationService.Find(localLicenseApplication.ApplicationID).Status == enApplicationStatus.eCompleted)
                throw new Exception($"Failed to Issue Local License in completed Application with ID [{localLicenseApplication.ApplicationID}].");

            int totalPassedTests = LocalLicenseApplicationService.GetTotalPassedTests(LocalLicenseApplicationID);
            if (totalPassedTests < 3)
                throw new Exception($"Failed to Issue Local License to Application with ID [{localLicenseApplication.ApplicationID}]. Because the applicant did not finished all the tests he only paassed {totalPassedTests} Tests");


            Driver driver = DriverService.FindByPersonID(localLicenseApplication.PersonID);

            if (driver == null)
            {
                int driverID = DriverService.Create(
                    localLicenseApplication.PersonID,
                    createdByUserID
                );

                driver = DriverService.Find(driverID);
            }

            if (driver == null)
                throw new Exception("Failed to create driver, while creating local license.");

            int licenseID = LicenseService.Create(issueTypeID, driver.DriverID, createdByUserID);

            if (licenseID == -1)
                throw new Exception("Failed to create license.");

            int result = LocalLicenseData.CreateLocalLicense(licenseID, localLicenseApplication.LicenseClassID);
            if (result != -1)
                ApplicationService.Complete(localLicenseApplication.ApplicationID);

            return result;
        }
    }
}
