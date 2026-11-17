using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class LocalLicenseData
    {
        public static int CreateLocalLicense(int LicenseID,int LicenseClassID)
        {
            int _LocalLicenseID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[LocalLicenses]
                            (
                                [LicenseID],
                                [LicenseClassID]
                            )
                            VALUES
                            (
                                @LicenseID,
                                @LicenseClassID
                            );
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    _LocalLicenseID = Convert.ToInt32(result);
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

            return _LocalLicenseID;
        }

        private static bool GetLicenseBy(string column, object val, ref int LocalLicenseID, ref int LicenseID, ref int LicenseClassID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $"SELECT * FROM LocalLicenses WHERE {column} = @Val;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Val", val);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LocalLicenseID = Convert.ToInt32(reader["LocalLicenseID"]);
                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);

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
        
        public static bool GetLicenseByLocalLicenseID(int LocalLicenseID, ref int LicenseID, ref int LicenseClassID)
        {
            return GetLicenseBy("LocalLicenseID", LocalLicenseID, ref LocalLicenseID, ref LicenseID, ref LicenseClassID);
        }
        public static bool GetLicenseByLicenseID(int LicenseID, ref int LocalLicenseID, ref int LicenseClassID)
        {
            return GetLicenseBy("LicenseID", LicenseID, ref LocalLicenseID, ref LicenseID, ref LicenseClassID);
        }

        public static bool isExist(int LocalLicenseID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = $@"SELECT CASE
                                WHEN EXISTS 
                                (
                                    SELECT 1
                                    FROM LocalLicenses
                                    WHERE LocalLicenseID = @ID
                                )
                                THEN 1
                                ELSE 0
                            END AS Found;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", LocalLicenseID);

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

        public static DataTable GetLocalLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalLicenses;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                dt.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetLocalLicensesForDriver(int driverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT LocalLicenses.LocalLicenseID, LocalLicenses.LicenseID,
                            LocalLicenses.LicenseClassID FROM LocalLicenses
                            INNER JOIN Licenses ON Licenses.LicenseID = LocalLicenses.LicenseID
                            WHERE Licenses.DriverID  = @DriverID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                connection.Open();

                dt.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetLocalLicensesForDriver_ForDisplay(int driverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT LocalLicenses.LocalLicenseID, Applications.ApplicationID,
                             LicenseClasses.ClassName, Licenses.IssueDate, DATEADD(YEAR, LicenseClasses.ValidityLength, Licenses.IssueDate)
                             AS ExpirationDate, 
                                CAST
                                (
                                CASE
                                	WHEN Licenses.IsActive = 1 AND CAST(DATEADD(YEAR, LicenseClasses.ValidityLength, Licenses.IssueDate) AS DATE) >= CAST(GETDATE() AS DATE) THEN 1
                                	ELSE 0
                                END AS BIT
                                ) AS Active
                             FROM LocalLicenses
                             INNER JOIN Licenses ON Licenses.LicenseID = LocalLicenses.LicenseID
                             INNER JOIN Applications ON Applications.ApplicationID = Licenses.ApplicationID
                             INNER JOIN LicenseClasses ON LicenseClasses.LicenseClassID = LocalLicenses.LicenseClassID
                             WHERE Licenses.DriverID  = @DriverID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);

            try
            {
                connection.Open();

                dt.Load(command.ExecuteReader());
            }
            catch (Exception ex)
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
