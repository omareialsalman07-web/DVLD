using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Business
{
    public static class ApplicationService
    {
        public static Application Find(int ID)
        {
            Application application = null;

            int ApplicationTypeID = -1;
            DateTime Date = DateTime.Now;
            byte Status = 0;
            float PaidFees = -1.0f;
            int CreatedByUserID = -1;

            if (ApplicationData.GetApplicationInfoByID(ID, ref ApplicationTypeID,
                ref Date, ref Status, ref PaidFees, ref CreatedByUserID))
            {
                application = new Application(
                    ID,
                    (enApplicationType)ApplicationTypeID,
                    Date,
                    (enApplicationStatus)Status,
                    PaidFees,
                    CreatedByUserID
                );
            }

            return application;
        }

        public static int Create(enApplicationType ApplicationType, DateTime Date,
            enApplicationStatus Status, float PaidFees, int CreatedByUserID)
        {
            return ApplicationData.CreateApplication(
                (int)ApplicationType,
                Date,
                (int)Status,
                PaidFees,
                CreatedByUserID
            );
        }

        public static bool Complete(int ApplicationID)
        {
            Application application = Find(ApplicationID);

            if (application == null)
                throw new Exception($"Application with ID {ApplicationID} does not exist.");

            if (application.Status == enApplicationStatus.eCancelled)
                throw new InvalidOperationException("Can't complete a canceled application!");

            if (application.Status == enApplicationStatus.eCompleted)
                throw new InvalidOperationException("This application is already completed!");

            return ApplicationData.CompleteApplication(ApplicationID);
        }

        public static bool Cancel(int ApplicationID)
        {
            Application application = Find(ApplicationID);

            if (application == null)
                throw new Exception($"Application with ID {ApplicationID} does not exist.");

            if (application.Status == enApplicationStatus.eCompleted)
                throw new InvalidOperationException("Can't cancel a completed application!");

            if (application.Status == enApplicationStatus.eCancelled)
                throw new InvalidOperationException("This application is already canceled!");

            return ApplicationData.CancelApplication(ApplicationID);
        }

        public static bool Delete(int ApplicationID)
        {
            return ApplicationData.DeleteApplication(ApplicationID);
        }

        public static List<Application> GetApplications()
        {
            List<Application> applicationsList = new List<Application>();

            DataTable data = ApplicationData.GetApplications();

            foreach (DataRow row in data.Rows)
            {
                Application application = new Application
                (
                    applicationID: Convert.ToInt32(row["ApplicationInfo"]),
                    date: Convert.ToDateTime(row["ApplicationDate"]),
                    applicationType: (enApplicationType)Convert.ToInt32(row["Date"]),
                    status: (enApplicationStatus)Convert.ToInt32(row["Status"]),
                    paidFees: Convert.ToSingle(row["PaidFees"]),
                    createdByUserID: Convert.ToInt32(row["CreatedByUserInfo"])
                );

                applicationsList.Add(application);
            }

            return applicationsList;
        }
        public static DataTable GetApplicationsByApplicationTypeID(enApplicationType applicationType)
        {
            return ApplicationData.GetApplicationsByApplicationTypeID((int)applicationType);
        }
        public static DataTable GetNewIntlLicenseApps()
        {
            return ApplicationData.GetNewIntlLicenseApps();
        }
    }
}