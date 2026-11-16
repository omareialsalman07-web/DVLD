using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
