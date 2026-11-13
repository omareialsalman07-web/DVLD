using System;

namespace DVLD_Business
{
    public class TestAppointment
    {
        public int TestAppointmentID { get; }
        public int TestID { get; }
        public DateTime Date { get; }
        public bool IsCancelled { get; }
        public bool IsTaked { get; }
        public float PaidFees { get; }
        public int CreatedByUserID { get; }
        public int RetakeTestApplicationID { get; }

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

            TestID = testID;
            Date = date;
            IsCancelled = isCancelled;
            IsTaked = isTaked;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            RetakeTestApplicationID = retakeTestApplicationID;
        }
        public TestAppointment(int testAppointmentID, int testID, DateTime date,
                               bool isCancelled, bool isTaked, float paidFees, int createdByUserID, int retakeTestApplicationID)
            : this(testID, date, isCancelled, isTaked, paidFees, createdByUserID, retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
        }
    }
}