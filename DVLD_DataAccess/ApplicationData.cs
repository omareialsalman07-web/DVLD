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
    internal static class ApplicationData
    {
        internal static int CreateApplication(int ApplicationTypeID, DateTime Date, byte Status, int CreateByUserID)
        {
            int _ID = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Applications]
                            ([ApplicationTypeID], [Date], [Status], [CreatedByUserID])
                            VALUES
                            (@ApplicationTypeID, @Date, @Status, @CreatedByUserID)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@Status", Status);
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
            catch(Exception ex)
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
        internal static bool isExistedByID(int ApplicationID)
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
        internal static byte GetApplicationStatus(int ApplicationID)
        {
            byte Status = 0;

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
        internal static bool CompleteApplication(int ApplicationID)
        {
            if (GetApplicationStatus(ApplicationID) == 1)
                throw new Exception("Can't Complete a canceled Application!");
            else if (GetApplicationStatus(ApplicationID) == 2)
                throw new Exception("This Application already completed!");

            return _UpdateApplicationStatus(ApplicationID, 2);
        }
        internal static bool CancelApplication(int ApplicationID)
        {
            if (GetApplicationStatus(ApplicationID) == 2)
                throw new Exception("Can't cancle a completed Application!");
            else if (GetApplicationStatus(ApplicationID) == 1)
                throw new Exception("This Application already canceled!");

            return _UpdateApplicationStatus(ApplicationID, 1);
        }
    }
}
