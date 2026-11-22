using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DVLD_Business
{
    public class TestAppointmentService
    {
        public static bool CanCreateAppointment(int LocalLicenseApplicationID)
        {
            LocalLicenseApplication localLicenseApplication;
            if ((localLicenseApplication = LocalLicenseApplicationService.Find(LocalLicenseApplicationID)) == null)
                throw new Exception($"Can't find local license applicaion with ID [{LocalLicenseApplicationID}]");

            Test test;
            if ((test = LocalLicenseApplicationService.GetCurrnetTest(localLicenseApplication.LocalLicenseApplicationID)) == null)
                return true;

            return TestAppointmentData.CanCreateAppointment(test.TestID);
        }

        private static int _GetRetakeTestApplicationIDForAppointment(int LocalLicenseApplicationID, enTestType testType, DateTime date, int createdByUserID)
        {
            int _RetakeTestApplicationID = -1;
            if (LocalLicenseApplicationService.HasTakenTestAppointment(LocalLicenseApplicationID, testType))
            {
                _RetakeTestApplicationID = ApplicationService.Create(
                    enApplicationType.eRetakeTest,
                    date,
                    (int)enApplicationStatus.eNew,
                    ApplicationTypeService.Find((int)enApplicationType.eRetakeTest).Fees,
                    createdByUserID);
            }
            
            return _RetakeTestApplicationID;
        }

        private static int _GetCurrentTestIDForAppointment(int LocalLicenseApplicationID, enTestType testType, int createdByUserID)
        {
            Test _Test = LocalLicenseApplicationService.GetCurrnetTest(LocalLicenseApplicationID);
            if (_Test == null) // There is no test currently created for this local license application and test type.
            {
                int _testID = TestService.CreateTest(testType, LocalLicenseApplicationID,
                    createdByUserID);

                if (_testID != -1)
                    _Test = LocalLicenseApplicationService.GetCurrnetTest(LocalLicenseApplicationID);
                else
                    throw new InvalidOperationException($"Some thing went wrong while creating test on Local Driving License Application ID [{LocalLicenseApplicationID}]!");
            }

            return _Test.TestID;
        }

        public static int ScheduleAppointment(int LocalLicenseApplicationID, enTestType testType, DateTime date, float paidFees, int createdByUserID)
        {
            if (date.Date < DateTime.Today)
                throw new InvalidOperationException("The appointment date cannot be in the past.");

            LocalLicenseApplication localLicenseApplication = LocalLicenseApplicationService.Find(LocalLicenseApplicationID);
            if(localLicenseApplication == null)
                throw new InvalidOperationException($"Could't find local driving license application with ID [{LocalLicenseApplicationID}]");

            int _TestID = _GetCurrentTestIDForAppointment(localLicenseApplication.LocalLicenseApplicationID, testType, createdByUserID);
            int _RetakeTestApplicationID = _GetRetakeTestApplicationIDForAppointment(localLicenseApplication.LocalLicenseApplicationID, testType, date, createdByUserID);

            TestAppointment appointment = new TestAppointment(_TestID, date, false, false, paidFees, createdByUserID, _RetakeTestApplicationID);

            int id = TestAppointmentData.CreateAppointment(appointment.TestID, appointment.Date,
                                                           appointment.PaidFees, appointment.CreatedByUserID, appointment.RetakeTestApplicationID);
            if (id == -1)
                throw new InvalidOperationException("The appointment could not be saved.");

            return id;
        }

        public static TestAppointment Find(int testAppointmentID)
        {
            if (testAppointmentID <= 0) throw new ArgumentOutOfRangeException(nameof(testAppointmentID));

            int testID = -1, createdBy = -1, retakeTestApplicationID = -1;
            DateTime date = DateTime.MinValue;
            bool isCancelled = false, isTaked = false;
            float fees = 0;

            if (!TestAppointmentData.GetAppointment(testAppointmentID, ref testID, ref date,
                                                    ref isCancelled, ref isTaked, ref fees, ref createdBy, ref retakeTestApplicationID))
            {
                return null;
            }
            return new TestAppointment(testAppointmentID, testID, date, isCancelled, isTaked, fees, createdBy, retakeTestApplicationID);
        }

        public static bool IsValidAppointment(int TestAppointmentID)
        {
            TestAppointment testAppointment = Find(TestAppointmentID);

            return !testAppointment.IsTaked && !testAppointment.IsCancelled && testAppointment.Date >= DateTime.Today;
        }

        public static bool UpdateAppointmentDate(int TestAppointmentID, DateTime NewDate)
        {
            if(!IsValidAppointment(TestAppointmentID))
                throw new Exception("Can't Edit this Appointment");

            return TestAppointmentData.UpdateAppointmentDate(TestAppointmentID, NewDate);
        }

        public static bool CanTakeTest(int TestAppointmentID)
        {
            return TestAppointmentData.CanTakeAppointment(TestAppointmentID);
        }

        public static bool TakeTest(int TestAppointmentID, bool Result, string Notes)
        {
            if(!TestAppointmentData.TakeAppointment(TestAppointmentID, Result, Notes))
            {
                throw new Exception($"Some thing went wen't wrong while taking the Test by Appointmnet ID {TestAppointmentID}");
            }

            TestAppointment testAppointment = Find(TestAppointmentID);
            if (testAppointment == null)
            {
                throw new Exception($"There is no Test Appointment with this ID {TestAppointmentID}");
            }
            if(!TestData.TakeTest(testAppointment.TestID, Result, Notes))
            {
                throw new Exception($"Some thing went wen't wrong while taking the Test by Appointmnet ID {TestAppointmentID}");
            }

            return true;
        }
        public static bool CancleAppointment(int TestAppointmentID)
        {
            return TestAppointmentData.CancleAppointment(TestAppointmentID);
        }

        public static List<TestAppointment> GetAppointments(int testID)
        {
            DataTable dt = TestAppointmentData.GetTestAppointments(testID);
            if (dt == null)
                return null;

            List<TestAppointment> testAppointments = new List<TestAppointment>();
            foreach(DataRow row in dt.Rows)
            {
                TestAppointment appointment = new TestAppointment
                (
                    testAppointmentID: Convert.ToInt32(row["TestAppointmentID"]), 
                    testID: Convert.ToInt32(row["TestID"]),
                    date: Convert.ToDateTime(row["Date"]),
                    isCancelled: Convert.ToBoolean(row["IsCancelled"]),
                    isTaked: Convert.ToBoolean(row["IsTaked"]),
                    paidFees: Convert.ToSingle(row["PaidFees"]),
                    createdByUserID: Convert.ToInt32(row["CreatedByUserID"]),
                    retakeTestApplicationID: (row["RetakeTestApplicationID"] != DBNull.Value) ? Convert.ToInt32(row["RetakeTestApplicationID"]) : -1
                );

                testAppointments.Add(appointment);
            }
            return testAppointments;
        }

        public static DataTable GetAppointmentsForDisplay(int LocalLicenseApplicationID, enTestType TestTypeID)
        {
            return TestAppointmentData.GetTestAppointmentsForDisplay(LocalLicenseApplicationID, (int)TestTypeID);
        }
    }
}