using System;

namespace DVLD_Business
{
    public class TestAppointment
    {
        public int TestAppointmentID { get; }
        public Test TestInfo { get; }
        public DateTime Date { get; }
        public bool IsCancelled { get; }
        public bool IsTaked { get; }
        public float PaidFees { get; }
        public User CreatedByUserInfo { get; }
        public Application RetakeTestApplicationInfo { get; }

        public bool IsExpired() { return Date < DateTime.Now; }

        public TestAppointment(int testID, DateTime date,
                               bool isCancelled, bool isTaked, float paidFees, int createdByUserID, int retakeTestApplicationID = -1)
        {
            if (testID <= 0)
                throw new ArgumentOutOfRangeException(nameof(testID));
            if (paidFees < 0)
                throw new ArgumentOutOfRangeException(nameof(paidFees), "Fees cannot be negative.");
            if (createdByUserID <= 0)
                throw new ArgumentOutOfRangeException(nameof(createdByUserID));

            TestInfo = TestService.Find(testID);
            Date = date;
            IsCancelled = isCancelled;
            IsTaked = isTaked;
            PaidFees = paidFees;
            CreatedByUserInfo = UserService.FindByUserID(createdByUserID);
            RetakeTestApplicationInfo = ApplicationService.Find(retakeTestApplicationID);
        }
        public TestAppointment(int testAppointmentID, int testID, DateTime date,
                               bool isCancelled, bool isTaked, float paidFees, int createdByUserID, int retakeTestApplicationID)
            : this(testID, date, isCancelled, isTaked, paidFees, createdByUserID, retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
        }
    }
}