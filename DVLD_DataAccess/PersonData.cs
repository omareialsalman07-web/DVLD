using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net;
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
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

                    reader.Close();
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
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address,
            string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int _ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[People] ([NationalNo], [FirstName], [SecondName], [ThirdName],
            [LastName], [DateOfBirth], [Gendor], [Address], [Phone], [Email], [NationalityCountryID], [ImagePath])
            VALUES 
            (@NationalNo, @FirstName, @SecondName, @ThirdName,
            @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            // Handle nullable optional parameters
            command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            // Handle nullable optional parameters
            command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            // Handle nullable optional parameters
            command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

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
        public static bool isExist(int ID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = $"SELECT Found=1 FROM People WHERE PersonID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                found = (result != null);

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
        public static bool isExist(string nationalNo)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = $"SELECT Found=1 FROM People WHERE NationalNo = @NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);

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

        public static bool UpdatePerson(int ID, string nationalNo, string firstName, string secondName,
    string thirdName, string lastName, DateTime dateOfBirth, int gendor, string address,
    string phone, string email, int nationalityCountryID, string imagePath)
        {
            // First, check if the person actually exists using your existing method
            if (!isExist(ID))
            {
                return false;
            }

            int rowsAffected = 0;
            string query = @"
        UPDATE [dbo].[People]
        SET [NationalNo] = @NationalNo,
            [FirstName] = @FirstName,
            [SecondName] = @SecondName,
            [ThirdName] = @ThirdName,
            [LastName] = @LastName,
            [DateOfBirth] = @DateOfBirth,
            [Gendor] = @Gendor,
            [Address] = @Address,
            [Phone] = @Phone,
            [Email] = @Email,
            [NationalityCountryID] = @NationalityCountryID,
            [ImagePath] = @ImagePath
        WHERE [PersonID] = @PersonID;";

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            // Pass parameters
            command.Parameters.AddWithValue("@PersonID", ID);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", secondName);
            command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(thirdName) ? (object)DBNull.Value : thirdName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gendor", gendor);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
            command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
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
        public static bool DeletePerson(int ID)
        {
            // Verify existence first
            if (!isExist(ID))
            {
                return false;
            }

            int rowsAffected = 0;
            string query = "DELETE FROM [dbo].[People] WHERE [PersonID] = @PersonID;";

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle or log exception (e.g., foreign key violation if the person is linked to a Local Driving License Application)
                rowsAffected = 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }

            return (rowsAffected > 0);
        }
    }
}
