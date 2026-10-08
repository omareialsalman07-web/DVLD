using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class TestTypeData
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = null;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestTypes;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                dt = new DataTable();
                dt.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetTestType(int ID, ref string Title, ref string Description, ref float Fees)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestTypes WHERE ID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Title = reader["Title"].ToString();
                    Description = reader["Description"].ToString();
                    Fees = Convert.ToSingle(reader["Fees"]);
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

        public static bool UpdateTestTypeInfo(int ID, string title, string description, float fees)
        {
            int rowEffected = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = $@"UPDATE [dbo].[TestTypes]
                            SET [Title] = @Title,
                                [Description] = @Description,
                                [Fees] = @Fees
                            WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@Fees", fees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                rowEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                rowEffected = 0;
                throw;
            }
            finally
            {
                connection.Close();
            }

            return rowEffected > 0;
        }
    }
}
