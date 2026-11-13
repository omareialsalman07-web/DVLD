using System;

namespace DVLD_Business
{
    public class Application
    {
        public int ApplicationID { get; }
        public int ApplicationTypeID { get; }
        public DateTime Date { get; }
        public enApplicationStatus Status { get; }
        public int CreatedByUserID { get; }

        public Application(int applicationTypeID, DateTime date,
                           enApplicationStatus status, int createdByUserID)
        {
            if (applicationTypeID <= 0)
                throw new ArgumentOutOfRangeException(nameof(applicationTypeID));

            if (!Enum.IsDefined(typeof(enApplicationStatus), status))
                throw new ArgumentException("A valid application status is required.", nameof(status));

            if (createdByUserID <= 0)
                throw new ArgumentOutOfRangeException(nameof(createdByUserID));

            ApplicationTypeID = applicationTypeID;
            Date = date;
            Status = status;
            CreatedByUserID = createdByUserID;
        }

        public Application(int applicationID, int applicationTypeID,
                           DateTime date, enApplicationStatus status, int createdByUserID)
            : this(applicationTypeID, date, status, createdByUserID)
        {
            if (applicationID <= 0)
                throw new ArgumentOutOfRangeException(nameof(applicationID));

            ApplicationID = applicationID;
        }
    }
}