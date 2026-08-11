using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class UserData
    {
        public static int AddNewUser(int PersonID, string UserName, string Password)
        {
            int _ID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "INSERT INTO Users VALUES (@PersonID, @UserName, @Password) SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

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
    }
}