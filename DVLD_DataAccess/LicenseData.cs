using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class LicenseData
    {
        public static int CreateLicense(int IssueTypeID, DateTime IssueDate, int DriverID, int CreatedByUserID)
        {
            int _TestID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Licenses]
                             ([IssueTypeID]
                             ,[IssueDate]
                             ,[DriverID]
                             ,[CreatedByUserID])
                            VALUES
                                  (@IssueTypeID, @IssueDate, @DriverID, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssueTypeID", IssueTypeID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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

        public static bool GetLicense(int LicenseID, ref int IssueTypeID, ref DateTime IssueDate, 
            ref int DriverID, ref int CreatedByUserID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $"SELECT * FROM Licenses WHERE LicenseID = @Val;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Val", LicenseID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IssueTypeID = Convert.ToInt32(reader["IssueTypeID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
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
    }
}
