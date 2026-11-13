using System;
using DVLD_DataAccess;

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
            int CreatedByUserID = -1;

            if (ApplicationData.GetApplicationInfoByID(ID, ref ApplicationTypeID,
                ref Date, ref Status, ref CreatedByUserID))
            {
                application = new Application(
                    ID,
                    ApplicationTypeID,
                    Date,
                    (enApplicationStatus)Status,
                    CreatedByUserID
                );
            }

            return application;
        }

        public static int Create(int ApplicationTypeID, DateTime Date,
            enApplicationStatus Status, int CreatedByUserID)
        {
            return ApplicationData.CreateApplication(
                ApplicationTypeID,
                Date,
                (int)Status,
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
    }
}