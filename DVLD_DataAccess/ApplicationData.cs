
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class ApplicationData
    {
        public static int CreateApplication(int ApplicationType, DateTime Date, int Status, float PaidFees, int CreateByUserID)
        {
            int _ID = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Applications]
                            ([ApplicationTypeID], [Date], [Status], [PaidFees], [CreatedByUserID])
                            VALUES
                            (@ApplicationTypeID, @Date, @Status, @PaidFees, @CreatedByUserID)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationType);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreateByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    _ID = int.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {
                _ID = -1;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return _ID;
        }

        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicationTypeID,
                                                  ref DateTime Date, ref byte Status, ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection =
                new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"SELECT *
                         FROM Applications
                         WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationTypeID = (int)reader["ApplicationTypeID"];
                            Date = (DateTime)reader["Date"];
                            Status = (byte)reader["Status"];
                            PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            CreatedByUserID = (int)reader["CreatedByUserID"];

                            isFound = true;
                        }
                    }
                }
            }

            return isFound;
        }
        public static bool isExistedByID(int ApplicationID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT fount = 1 FROM Applications
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
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

        public static int GetApplicationStatus(int ApplicationID)
        {
            int Status = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT [Status]
                     FROM [dbo].[Applications]
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    Status = Convert.ToByte(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return Status;
        }

        private static bool _UpdateApplicationStatus(int ApplicationID, byte newStatus)
        {
            if (!isExistedByID(ApplicationID))
            {
                throw new Exception($"There is no existing Application with ID: {ApplicationID}");
            }

            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Applications]
                     SET [Status] = @newStatus
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@newStatus", newStatus);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                success = rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                command.Dispose();
                connection.Dispose();
            }

            return success;
        }

        public static bool CompleteApplication(int ApplicationID)
        {
            return _UpdateApplicationStatus(ApplicationID, 2);
        }

        public static bool CancelApplication(int ApplicationID)
        {
            return _UpdateApplicationStatus(ApplicationID, 1);
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            if (!isExistedByID(ApplicationID))
            {
                throw new Exception($"There is no existing Application with ID: {ApplicationID}");
            }

            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[Applications]
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                success = rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                command.Dispose();
                connection.Dispose();
            }

            return success;
        }

        public static DataTable GetApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Applications;";

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
        public static DataTable GetApplicationsByApplicationTypeID(int ApplicationTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Applications
                            WHERE Applications.ApplicationTypeID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ApplicationTypeID);

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
        public static DataTable GetNewIntlLicenseApps()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT InternationalLicenses.LicenseID, Applications.ApplicationID,
                             Licenses.DriverID, InternationalLicenses.LocalLicenseID, Licenses.IssueDate,
                             CAST(DATEADD(YEAR, 1, Licenses.IssueDate) AS DATE) AS ExpirationDate, Licenses.IsActive
                             FROM Applications
                             INNER JOIN Licenses ON Licenses.ApplicationID = Applications.ApplicationID
                             INNER JOIN InternationalLicenses ON 
                             InternationalLicenses.LicenseID = Licenses.LicenseID
                             WHERE Applications.ApplicationTypeID = 6;";

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
    }
}