using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class UserData
    {
        public static int AddNewUser(int PersonID, string UserName, string Password, bool isActive)
        {
            int _ID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "INSERT INTO Users VALUES (@PersonID, @UserName, @Password, @IsActive) SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", isActive);

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
        private static bool GetUserBy(string column, object val, ref int UserID, ref int personID, ref string userName, ref string password, ref bool isActive)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $"SELECT * FROM Users WHERE Users.{column} = @Val;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Val", val);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UserID = Convert.ToInt32(reader["UserID"]);
                    personID = Convert.ToInt32(reader["PersonID"]);
                    userName = reader["UserName"].ToString();
                    password = reader["Password"].ToString();
                    isActive = Convert.ToBoolean(reader["IsActive"]);

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
        public static DataTable GetAllUser()
        {
            DataTable tb = null;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                tb = new DataTable();
                tb.Load(command.ExecuteReader());
            }
            catch(Exception ex)
            {
                tb = null;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return tb;
        }
        public static bool GetUserByUserID(int UserID, ref int personID, ref string userName, ref string password, ref bool isActive)
        {
            return GetUserBy("UserID", UserID, ref UserID, ref personID, ref userName, ref password, ref isActive);
        }
        public static bool GetUserByUserName(string UserName, ref int UserID, ref int personID, ref string password, ref bool isActive)
        {
            return GetUserBy("UserName", UserName, ref UserID, ref personID, ref UserName, ref password, ref isActive);
        }
        public static bool isExist(int UserID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $"SELECT Found=1 FROM Users WHERE UserID = @UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

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
        public static bool isExist(string userName)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $"SELECT Found=1 FROM Users WHERE UserName = @UserName;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", userName);

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
        public static bool UpdateUser(int ID, int personID, string userName, string password, bool isActive)
        {
            if (!isExist(ID))
                return false;

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Users] 
                            SET [PersonID] = @PersonID, [UserName] = @UserName ,[Password] = @Password, 
                            [IsActive] = @IsActive 
                            WHERE UserID = @User_ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@User_ID", ID);
            command.Parameters.AddWithValue("@PersonID", personID);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                rowsAffected = 0;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool SetActive(int ID, bool val)
        {
            if (!isExist(ID))
                return false;

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Users] 
                            SET [IsActive] = @IsActive 
                            WHERE UserID = @User_ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@User_ID", ID);
            command.Parameters.AddWithValue("@IsActive", val);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                rowsAffected = 0;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }      
        public static bool DeleteUser(int ID)
        {
            if (!isExist(ID))
                return false;

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "DELETE FROM [dbo].[Users] WHERE [UserID] = @UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            {
                rowsAffected = 0;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}