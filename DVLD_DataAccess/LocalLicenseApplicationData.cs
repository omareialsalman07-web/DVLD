using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public static class LocalLicenseApplicationData
    {
        private static bool _CanCreateLocalLicenceApplication(int PersonID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT found = 1 FROM (
                            SELECT Applications.ApplicationTypeID, LocalLicenseApplications.PersonID,
                            Applications.Status FROM LocalLicenseApplications
                            INNER JOIN Applications
                            ON LocalLicenseApplications.ApplicationID = Applications.ApplicationID
                            ) R1
                            WHERE R1.ApplicationTypeID = 1 and R1.PersonID = @PersonID and (R1.Status = 0 or R1.Status = 2);
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                success = (result == null);
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
        public static int CreateLocalLicenseApplication(int LicenseClassID, int PersonID, int CreatedByUserID)
        {
            if (!_CanCreateLocalLicenceApplication(PersonID))
            {
                throw new InvalidOperationException("This person already has an active or finished local driving license application.");
            }

            int _LocalLicenseID = 0;
            int _ApplicationID = ApplicationData.CreateApplication(1, DateTime.Today, 0, CreatedByUserID);
            if (_ApplicationID == -1)
                return -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[LocalLicenseApplications]
                            ([ApplicationID], [LicenseClassID], [PersonID])
                            VALUES
                            (@ApplicationID, @LicenseClassID, @PersonID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", _ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    _LocalLicenseID = int.Parse(result.ToString());
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
        public static bool isExistedByID(int LocalLicenseApplicationID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT fount = 1 FROM LocalLicenseApplications
                             WHERE LocalLicenseApplicationID = @LocalLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
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
        public static bool GetLocalLicenseApplicationByID(int LocalLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID, ref int PersonID)
        {
            bool success = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalLicenseApplications
                             WHERE LocalLicenseApplicationID = @LocalLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    success = true;

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                }
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
        public static DataTable GetAllLocalLicenseApplications()
        {
            DataTable dt = new DataTable(); ;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalLicenseApplications;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null)
                    dt.Load(reader);
                else
                    dt = null;
            }
            catch (Exception ex)
            {
                dt = null;
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetAllLocalLicenseApplications_ForDisplay()
        {
            DataTable dt = new DataTable(); ;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT LocalLicenseApplications.ApplicationID, LicenseClasses.ClassName, 
                            People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') +
                            People.LastName AS FullName, Applications.Status FROM LocalLicenseApplications
                            INNER JOIN People 
                            ON LocalLicenseApplications.PersonID = People.PersonID
                            INNER JOIN LicenseClasses 
                            ON LocalLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                            INNER JOIN Applications
                            ON LocalLicenseApplications.ApplicationID = Applications.ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null)
                    dt.Load(reader);
                else
                    dt = null;
            }
            catch (Exception ex)
            {
                dt = null;
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool CompleteLocalLicenseApplication(int LocalLicenseApplicationID)
        {
            int ApplicationID = 0, LicenseClassID = 0, PersonID = 0;
            if (GetLocalLicenseApplicationByID(LocalLicenseApplicationID, ref ApplicationID, ref LicenseClassID, ref PersonID))
                return ApplicationData.CompleteApplication(ApplicationID);
            else
                return false;
        }
        public static bool CancleLocalLicenseApplication(int LocalLicenseApplicationID)
        {
            int ApplicationID = 0, LicenseClassID = 0, PersonID = 0;
            if (GetLocalLicenseApplicationByID(LocalLicenseApplicationID, ref ApplicationID, ref LicenseClassID, ref PersonID))
                return ApplicationData.CancelApplication(ApplicationID);
            else
                return false;
        }
    }
}
