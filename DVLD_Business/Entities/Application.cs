using System;

namespace DVLD_Business
{
    public class Application
    {
        public int ApplicationID { get; }
        public enApplicationType Type { get; }
        public DateTime Date { get; }
        public enApplicationStatus Status { get; }
        public float PaidFees { get; set; }
        public User CreatedByUserInfo { get; }

        public Application(enApplicationType applicationType, DateTime date,
                           enApplicationStatus status, float paidFees, int createdByUserID)
        {
            if (!Enum.IsDefined(typeof(enApplicationStatus), status))
                throw new ArgumentException("A valid application status is required.", nameof(status));

            if (createdByUserID <= 0)
                throw new ArgumentOutOfRangeException(nameof(createdByUserID));

            Type = applicationType;
            Date = date;
            Status = status;
            PaidFees = paidFees;
            CreatedByUserInfo = UserService.FindByUserID(createdByUserID);
        }

        public Application(int applicationID, enApplicationType applicationType,
                           DateTime date, enApplicationStatus status, float paidFees, int createdByUserID)
            : this(applicationType, date, status, paidFees, createdByUserID)
        {
            if (applicationID <= 0)
                throw new ArgumentOutOfRangeException(nameof(applicationID));

            ApplicationID = applicationID;
        }
    }
}