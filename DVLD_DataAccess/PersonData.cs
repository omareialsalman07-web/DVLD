using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class PersonData
    {
        public static bool GetPersonByID(int ID, ref string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address,
            ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (int)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = (string)reader["ImagePath"];

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

        
    }
}
