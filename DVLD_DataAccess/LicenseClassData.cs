using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class LicenseClassData
    {
        public static bool GetLicenseClassByID(int id, ref string ClassName, 
            ref string ClassDescription,  ref byte MinimumAllowedAge, ref byte ValidityLength, ref float ClassFees)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                    ValidityLength = Convert.ToByte(reader["ValidityLength"]);
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
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
        public static DataTable GetAllLicenseClasses()
        {
            DataTable data = null;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    data = new DataTable();
                    data.Load(reader);
                }
            }
            catch
            {
                data = null;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return data;
        }
    }
}

