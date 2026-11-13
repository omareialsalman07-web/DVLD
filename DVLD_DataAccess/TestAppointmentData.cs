using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccess.TestData;

namespace DVLD_DataAccess
{
    public static class TestAppointmentData
    {
        public static bool CanCreateAppointment(int TestID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT CASE
                                WHEN EXISTS
                                (
                                    SELECT 1
                                    FROM Tests
                                    WHERE TestID = @TestID
                                      AND Result = 1
                                )
                                THEN 0

                                WHEN EXISTS
                                (
                                    SELECT 1
                                    FROM TestAppointments
                                    WHERE TestID = @TestID
                                      AND IsCancelled = 0
                                      AND IsTaked = 0
                                      AND Date >= CAST(GETDATE() AS DATE)
                                )
                                THEN 0

                                WHEN EXISTS
                                (
                                    SELECT 1
                                    FROM Tests
                                    INNER JOIN LocalLicenseApplications
                                        ON Tests.LocalLicenseApplicationID =
                                           LocalLicenseApplications.LocalLicenseApplicationID
                                    INNER JOIN Applications
                                        ON LocalLicenseApplications.ApplicationID =
                                           Applications.ApplicationID
                                    WHERE Tests.TestID = @TestID
                                      AND Applications.Status IN (1, 2)
                                )
                                THEN 0

                                ELSE 1
                            END;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", (int)TestID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                success = Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }
        public static int CreateAppointment(int TestID, DateTime Date, float PaidFees, int CreatedByUserID, int RetakeTestApplicationID = -1)
        {
            int _AppointmentID = -1;

            if (!CanCreateAppointment(TestID))
            {
                throw new InvalidOperationException("Can't Create Appointment for this test.");
            }

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[TestAppointments]
                            ([TestID], [Date], [IsCancelled], [IsTaked],
                            [PaidFees], [CreatedByUserID], [RetakeTestApplicationID])
                            VALUES
                            (@TestID, @Date, 0, 0,
                            @PaidFees, @CreatedByUserID, @RetakeTestApplicationID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", (int)TestID);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID == -1 ? (object)DBNull.Value : RetakeTestApplicationID); ;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    _AppointmentID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return _AppointmentID;
        }

        public static bool UpdateAppointmentDate(int TestAppointmentID, DateTime NewDate)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[TestAppointments]
                            SET
                                [Date] = @NewDate
                            WHERE TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewDate", NewDate);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                int rowEffected = command.ExecuteNonQuery();
                success = (rowEffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }


        public static bool GetAppointment(int TestAppointmentID, ref int TestID, ref DateTime Date, 
            ref bool IsCancelled, ref bool IsTaked, ref float PaidFees, ref int CreatedByUserID, ref int RetakeTestApplicationID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestID = Convert.ToInt32(reader["TestID"]);
                    Date = Convert.ToDateTime(reader["Date"]);
                    IsCancelled = Convert.ToBoolean(reader["IsCancelled"]);
                    IsTaked = Convert.ToBoolean(reader["IsTaked"]);
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    if (reader["RetakeTestApplicationID"] != DBNull.Value)
                        RetakeTestApplicationID = Convert.ToInt32(reader["RetakeTestApplicationID"]);
                    else
                        RetakeTestApplicationID = -1;

                    found = true;
                }
            }
            catch (Exception ex)
            {
                found = false;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return found;
        }

        public static bool CanTakeAppointment(int TestAppointmentID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT found = 1
                            WHERE EXISTS
                            (
                                SELECT TOP 1 R = 'Y' FROM TestAppointments
                                WHERE TestAppointments.TestAppointmentID = @TestAppointmentID and 
                                TestAppointments.Date = CAST(GETDATE() AS DATE) and 
                                TestAppointments.IsCancelled = 0 and TestAppointments.IsTaked = 0
                            );";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                success = (result != null);
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        public static bool TakeAppointment(int TestAppointmentID, bool Result, string Notes)
        {
            if(!CanTakeAppointment(TestAppointmentID))
            {
                throw new Exception("Can't this test. Check that the appointment is exsited and not expired or not cancelled!");
            }

            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[TestAppointments]
                            SET
                                [IsTaked] = 1
                            WHERE TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                int rowEffected = command.ExecuteNonQuery();
                success = (rowEffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }
        public static bool CancleAppointment(int TestAppointmentID)
        {
            int testType = -1, TestID = -1, retakeTestApplicationID = -1;
            DateTime Date = DateTime.MinValue;
            bool IsCancelled = false, IsTaked = false;
            float PaidFees = -1.0f;
            int CreatedByUserID = -1;

            if (!GetAppointment(TestAppointmentID, ref TestID, ref Date, ref IsCancelled, ref IsTaked, ref PaidFees, ref CreatedByUserID, ref retakeTestApplicationID))
            {
                throw new Exception($"There is no Test Appointment with this ID {TestAppointmentID}");
            }
            
            
            if (IsTaked || Date < DateTime.Today)
            {
                throw new Exception($"Can't cancel this appintment as it already taked or excpired!");
            }

            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[TestAppointments]
                            SET
                                [IsCancelled] = 1
                            WHERE TestAppointments.TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                int rowEffected = command.ExecuteNonQuery();
                success = (rowEffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }
        public static DataTable GetTestAppointments(int TestID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM TestAppointments 
                           WHERE TestAppointments.TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                dt.Load(command.ExecuteReader());
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetTestAppointmentsForDisplay(int LocalLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT TestAppointments.TestAppointmentID,
                            TestAppointments.Date, TestAppointments.IsCancelled,
                            TestAppointments.IsTaked, TestAppointments.PaidFees,
                            CAST
                            (
                                CASE
                                     WHEN TestAppointments.Date < CAST(GETDATE() AS DATE) THEN 1
                                     ELSE 0
                                END AS BIT
                            ) AS Expired
                            FROM TestAppointments
                            INNER JOIN Tests 
                            ON Tests.TestID = TestAppointments.TestID
                            WHERE Tests.LocalLicenseApplicationID = @LocalLicenseApplicationID 
                            AND Tests.TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                dt.Load(command.ExecuteReader());
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
