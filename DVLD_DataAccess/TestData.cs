
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class TestData
    {
        public static bool CanCreateTest(int testTypeID, int LLA_ID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT CASE
                                WHEN EXISTS
                                (
                                    SELECT R = 'Y' FROM LocalLicenseApplications
                                    INNER JOIN Applications
                                    ON Applications.ApplicationID = LocalLicenseApplications.ApplicationID
                                    WHERE LocalLicenseApplications.LocalLicenseApplicationID = @LocalLicenseApplicationID and 
                                    Applications.Status IN (1, 2)
                                )
                                THEN 0
                                WHEN EXISTS
                                (
                                    SELECT R = 'Y' FROM Tests
                                    WHERE Tests.TestTypeID = @TestTypeID and 
                                    Tests.LocalLicenseApplicationID = @LocalLicenseApplicationID
                                    AND (Tests.Result = 1 OR Tests.Result IS NULL)
                                )
                                THEN 0
                                ELSE 1
                            END;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", (int)LLA_ID);

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

        public static bool IsPassedTest(int TestType, int LLA_ID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT found = 1
                            WHERE EXISTS
                            (
                                SELECT R = 'Y' FROM Tests
                                WHERE Tests.TestTypeID = @TestTypeID and 
                                Tests.LocalLicenseApplicationID = @LocalLicenseApplicationID and 
                                Tests.Result = 1
                            );";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestType);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", (int)LLA_ID);

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

        public static int CreateTest(int TestType, int PrequistTestType, int LLA_ID, int CreatedByUserID)
        {
            if (!CanCreateTest(TestType, LLA_ID))
            {
                throw new InvalidOperationException("This person already has an active or finished local driving license application.");
            }

            int _TestID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Tests]
                        ([TestTypeID]
                        ,[PrerequisiteTestTypeID]
                        ,[LocalLicenseApplicationID]
                        ,[CreatedByUserID])
                        VALUES
                        (@TestTypeID, @PrerequisiteTestTypeID,
                        @LocalLicenseApplicationID, @CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestType);
            command.Parameters.AddWithValue("@PrerequisiteTestTypeID", (PrequistTestType == -1) ? (object)DBNull.Value : PrequistTestType);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", LLA_ID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    _TestID = Convert.ToInt32(result);
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

            return _TestID;
        }


        public static bool GetTestByID(int TestID, ref int TestType, ref int PrequistTestType,
            ref bool? Result, ref string Notes, ref int LLA_ID, ref int CreatedByUserID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests WHERE TestID = @TestID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    TestID = Convert.ToInt32(reader["TestID"]);
                    TestType = Convert.ToInt32(reader["TestTypeID"]);

                    if (reader["PrerequisiteTestTypeID"] != DBNull.Value)
                        PrequistTestType = Convert.ToInt32(reader["PrerequisiteTestTypeID"]);
                    else
                        PrequistTestType = -1;

                    if (reader["Result"] != DBNull.Value)
                        Result = Convert.ToBoolean(reader["Result"]);
                    else
                        Result = null;

                    if (reader["Notes"] != DBNull.Value)
                        Notes = reader["Notes"].ToString();
                    else
                        Notes = "";

                    LLA_ID = Convert.ToInt32(reader["LocalLicenseApplicationID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                    found = true;
                }

                reader.Close();
            }
            catch (Exception)
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

        public static bool GetTestByLocalLicenseAppID(int LocalLicenseApplicationID, ref int TestID, ref int TestType, ref int PrequistTestType,
            ref bool? Result, ref string Notes, ref int CreatedByUserID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Tests
                            WHERE Tests.LocalLicenseApplicationID = @LocalLicenseApplicationID and
                            Tests.Result is null;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestID = Convert.ToInt32(reader["TestID"]);
                    TestType = Convert.ToInt32(reader["TestTypeID"]);

                    if (reader["PrerequisiteTestTypeID"] != DBNull.Value)
                        PrequistTestType = Convert.ToInt32(reader["PrerequisiteTestTypeID"]);
                    else
                        PrequistTestType = -1;

                    if(reader["Result"] != DBNull.Value)
                        Result = Convert.ToBoolean(reader["Result"]);
                    else
                        Result = null;
                    if (reader["Notes"] != DBNull.Value)
                        Notes = reader["Notes"].ToString();
                    else
                        Notes = "";

                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

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

        public static bool TakeTest(int TestID, bool result, string notes)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[Tests]
                            SET
                                [Result] = @Result,
                                [Notes] = @Notes
                            WHERE Tests.TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@Result", result);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes);

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
    }
}
