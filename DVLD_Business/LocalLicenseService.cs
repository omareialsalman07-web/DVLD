
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Business
{
    public static class LocalLicenseService
    {
        public static LocalLicense FindByLocalLicenseID(int localLicenseID)
        {
            int licenseID = -1;
            int licenseClassID = -1;

            if (!LocalLicenseData.GetLicenseByLocalLicenseID(localLicenseID, ref licenseID, ref licenseClassID))
            {
                return null;
            }

            return new LocalLicense(localLicenseID, licenseID, licenseClassID);
        }
        public static LocalLicense FindByLicenseID(int licenseID)
        {
            int locallicenseID = -1;
            int licenseClassID = -1;

            if (!LocalLicenseData.GetLicenseByLicenseID(licenseID, ref locallicenseID, ref licenseClassID))
            {
                return null;
            }

            return new LocalLicense(locallicenseID, licenseID, licenseClassID);
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
                throw new Exception("Failed to create localLicense, while creating local license.");

            int licenseID = LicenseService.Create(issueTypeID, driver.DriverID, localLicenseApplication.ApplicationID, createdByUserID);

            if (licenseID == -1)
                throw new Exception("Failed to create license.");

            int result = LocalLicenseData.CreateLocalLicense(licenseID, localLicenseApplication.LicenseClassID);
            if (result != -1)
                ApplicationService.Complete(localLicenseApplication.ApplicationID);

            return result;
        }

        public static bool isExist(int LocalLicenseID)
        {
            return LocalLicenseData.isExist(LocalLicenseID);
        }

        public static List<LocalLicense> GetLocalLicenses()
        {
            List<LocalLicense> localLicensesList = new List<LocalLicense>();

            DataTable data = LocalLicenseData.GetLocalLicenses();
            foreach (DataRow row in data.Rows)
            {
                LocalLicense localLicense = new LocalLicense
                (
                    localLicenseID: Convert.ToInt32(row["LocalLicenseID"]),
                    licenseID: Convert.ToInt32(row["LicenseID"]),
                    licenseClassID: Convert.ToInt32(row["LicenseClassID"])
                );

                localLicensesList.Add(localLicense);
            }

            return localLicensesList;
        }
        public static List<LocalLicense> GetLocalLicensesForDriver(int driverID)
        {
            List<LocalLicense> localLicensesList = new List<LocalLicense>();

            DataTable data = LocalLicenseData.GetLocalLicensesForDriver(driverID);
            foreach (DataRow row in data.Rows)
            {
                LocalLicense driver = new LocalLicense
                (
                    localLicenseID: Convert.ToInt32(row["LocalLicenseID"]),
                    licenseID: Convert.ToInt32(row["LicenseID"]),
                    licenseClassID: Convert.ToInt32(row["LicenseClassID"])
                );

                localLicensesList.Add(driver);
            }

            return localLicensesList;
        }
        public static DataTable GetLocalLicensesForDriver_ForDisplay(int driverID)
        {
            return LocalLicenseData.GetLocalLicensesForDriver_ForDisplay(driverID);
        }
    }
}
