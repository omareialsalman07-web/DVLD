using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class DriverData
    {
        public static int CreateDriver(int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            int _DriverID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Drivers]
                                  ([PersonID]
                                  ,[CreatedDate]
                                  ,[CreatedByUserID])
                            VALUES
                            (
                                @PersonID,
                                @CreatedDate,
                                @CreatedByUserID
                            );
                                  SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    _DriverID = Convert.ToInt32(result);
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

            return _DriverID;
        }
        private static bool GetDriverBy(string column, object val, ref int DriverID, 
            ref int PersonID, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $"SELECT * FROM Drivers WHERE {column} = @Val;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Val", val);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
        public static bool GetDriverByDriverID(int DriverID, ref int PersonID, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            return GetDriverBy("DriverID", DriverID, ref DriverID, ref PersonID, ref CreatedDate, ref CreatedByUserID);
        }
        public static bool GetDriverByPersonID(int PersonID, ref int DriverID, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            return GetDriverBy("PersonID", PersonID, ref DriverID, ref PersonID, ref CreatedDate, ref CreatedByUserID);
        }

        private static bool isExistBy(string column, int ID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = $@"SELECT CASE
                                WHEN EXISTS 
                                (
                                    SELECT 1
                                    FROM Drivers
                                    WHERE {column} = @ID
                                )
                                THEN 1
                                ELSE 0
                            END AS Found;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

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

        public static bool isExistByDriverID(int DriverID)
        {
            return isExistBy("DriverID", DriverID);
        }
        public static bool isExistByPersonID(int PersonID)
        {
            return isExistBy("PersonID", PersonID);
        }

        public static DataTable GetDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM dbo.Drivers;";

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
        public static DataTable GetDriversForDisplay()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT Drivers.DriverID, 
                            People.FirstName + ' ' + People.SecondName + ' ' +
                            ISNULL(People.ThirdName, '') + ' ' + People.LastName as FullName,
                            Drivers.CreatedDate, Users.UserName
                            FROM dbo.Drivers
                            INNER JOIN People ON People.PersonID = Drivers.PersonID
                            INNER JOIN Users ON Users.UserID = Drivers.CreatedByUserID;";

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
