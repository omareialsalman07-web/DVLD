using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class CountryData
    {
        public static bool GetCountryByID(int id, ref string countryName)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    countryName = (string)reader[1];
                    found = true;
                }
            }
            catch(Exception ex)
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
        public static DataTable GetAllCountries()
        {
            DataTable data = null;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Countries;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader != null && reader.HasRows)
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
