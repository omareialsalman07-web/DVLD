using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class LicenseData
    {
        public static int CreateLicense(int IssueTypeID, DateTime IssueDate, int DriverID, int ApplicationID, int CreatedByUserID)
        {
            int _TestID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Licenses]
                             ([IssueTypeID]
                             ,[IssueDate]
                             ,[DriverID]
                             ,[ApplicationID]
                             ,[CreatedByUserID])
                            VALUES
                                  (@IssueTypeID, @IssueDate, @DriverID, @ApplicationID, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssueTypeID", IssueTypeID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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

        private static bool GetLicenseBy(string column, object val, ref int LicenseID, ref int IssueTypeID, ref DateTime IssueDate, 
            ref int DriverID, ref int ApplicationID, ref bool IsActive, ref int CreatedByUserID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $"SELECT * FROM Licenses WHERE {column} = @Val;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Val", val);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    IssueTypeID = Convert.ToInt32(reader["IssueTypeID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                    reader.Close();
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
        public static bool GetLicenseByLicenseID(int LicenseID, ref int IssueTypeID, ref DateTime IssueDate, 
            ref int DriverID, ref int ApplicationID, ref bool IsActive, ref int CreatedByUserID)
        {
            return GetLicenseBy("LicenseID", LicenseID, ref LicenseID, ref IssueTypeID,
                ref IssueDate, ref DriverID, ref ApplicationID, ref IsActive, ref CreatedByUserID);
        }
        public static bool GetLicenseByApplicationID(int ApplicationID, ref int LicenseID, ref int IssueTypeID, ref DateTime IssueDate, 
            ref int DriverID, ref bool IsActive, ref int CreatedByUserID)
        {
            return GetLicenseBy("ApplicationID", ApplicationID, ref LicenseID, ref IssueTypeID,
                ref IssueDate, ref DriverID, ref ApplicationID, ref IsActive, ref CreatedByUserID);
        }

        public static bool isExist(int LicenseID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = $@"SELECT CASE
                                WHEN EXISTS 
                                (
                                    SELECT 1
                                    FROM Licenses
                                    WHERE LicenseID = @ID
                                )
                                THEN 1
                                ELSE 0
                            END AS Found;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                found = (result != null);

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

        public static bool DeactivateLicense(int LicenseID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[Licenses]
                             SET 
                                 [IsActive] = 0
                             WHERE Licenses.LicenseID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", LicenseID);

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                success = (result > 0);

            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        public static int GetTotalAvailableLicensesForDriver(int driverID)
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT
                            (
                            	SELECT 
                            	(
                            		SELECT COUNT(*) FROM LocalLicenses
                            		INNER JOIN Licenses ON Licenses.LicenseID = LocalLicenses.LicenseID
                            		INNER JOIN LicenseClasses ON LicenseClasses.LicenseClassID = LocalLicenses.LicenseClassID
                            		WHERE Licenses.DriverID = @DriverID AND Licenses.IsActive = 1 AND 
                            		CAST(DATEADD(YEAR, LicenseClasses.ValidityLength, Licenses.IssueDate) AS DATE) >= CAST(GETDATE() AS DATE)
                            	)
                            	+
                            	(
                            		SELECT COUNT(*) FROM InternationalLicenses
                            		INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.LicenseID
                            		INNER JOIN LocalLicenses ON LocalLicenses.LocalLicenseID = InternationalLicenses.LocalLicenseID
                            		INNER JOIN LicenseClasses ON LicenseClasses.LicenseClassID = LocalLicenses.LicenseClassID
                            		WHERE Licenses.DriverID = @DriverID AND Licenses.IsActive = 1 AND 
                            		CAST(DATEADD(YEAR, LicenseClasses.ValidityLength, Licenses.IssueDate) AS DATE) >= CAST(GETDATE() AS DATE)
                            	)
                            ) AS AvailableLicenses;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                connection.Open();

                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return count;
        }
    }
}
