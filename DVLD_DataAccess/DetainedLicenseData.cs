
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public static class DetainedLicenseData
    {
        public static bool GetByDetainedLicenseID(int DetainedLicenseID, ref int LicenseID, ref bool IsReleased,
            ref DateTime DetainedDate, ref DateTime? ReleasedDate, ref int CreatedByUserID,
            ref int? ReleasedByUserID, ref float FineFees, ref int? ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM DetainedLicenses
                             WHERE DetainedLicenseID = @DetainedLicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DetainedLicenseID", DetainedLicenseID);

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();
                Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = (int)Reader["LicenseID"];
                    IsReleased = (bool)Reader["IsReleased"];
                    DetainedDate = (DateTime)Reader["DetainedDate"];

                    ReleasedDate = Reader["ReleasedDate"] == DBNull.Value
                        ? (DateTime?)null : (DateTime)Reader["ReleasedDate"];

                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    ReleasedByUserID = Reader["ReleasedByUserID"] == DBNull.Value
                        ? (int?)null : (int)Reader["ReleasedByUserID"];

                    FineFees = (float)Reader["FineFees"];

                    ReleaseApplicationID = Reader["ReleaseApplicationID"] == DBNull.Value
                        ? (int?)null : (int)Reader["ReleaseApplicationID"];

                    IsFound = true;
                }
            }
            finally
            {
                if (Reader != null)
                    Reader.Close();

                Connection.Close();
                Connection.Dispose();
                Command.Dispose();
            }

            return IsFound;
        }

        public static bool GetActiveByLicenseID(int LicenseID, ref int DetainedLicenseID, ref bool IsReleased,
            ref DateTime DetainedDate, ref DateTime? ReleasedDate, ref int CreatedByUserID,
            ref int? ReleasedByUserID, ref float FineFees, ref int? ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"
                            SELECT TOP 1 *
                            FROM DetainedLicenses
                            WHERE LicenseID = @LicenseID
                              AND IsReleased = 0
                            ORDER BY DetainedLicenseID DESC;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    DetainedLicenseID = (int)Reader["DetainedLicenseID"];
                    IsReleased = (bool)Reader["IsReleased"];
                    DetainedDate = (DateTime)Reader["DetainedDate"];
                    ReleasedDate = Reader["ReleasedDate"] == DBNull.Value
                        ? (DateTime?)null : (DateTime)Reader["ReleasedDate"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    ReleasedByUserID = Reader["ReleasedByUserID"] == DBNull.Value
                        ? (int?)null : (int)Reader["ReleasedByUserID"];
                    FineFees = Convert.ToSingle(Reader["FineFees"]);
                    ReleaseApplicationID = Reader["ReleaseApplicationID"] == DBNull.Value
                        ? (int?)null : (int)Reader["ReleaseApplicationID"];
                }

                Reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                Connection.Close();
                Command.Dispose();
                Connection.Dispose();
            }

            return IsFound;
        }

        public static int Create(int LicenseID, DateTime DetainedDate, float FineFees, int CreatedByUserID)
        {
            int DetainedLicenseID = -1;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO DetainedLicenses
                             (LicenseID, DetainedDate, CreatedByUserID, FineFees)
                             VALUES
                             (@LicenseID, @DetainedDate, @CreatedByUserID, @FineFees);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainedDate", DetainedDate);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@FineFees", FineFees);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
                    DetainedLicenseID = Convert.ToInt32(Result);
            }
            finally
            {
                Connection.Close();
                Connection.Dispose();
                Command.Dispose();
            }

            return DetainedLicenseID;
        }

        public static bool Release(int DetainedLicenseID, DateTime ReleasedDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"UPDATE DetainedLicenses
                             SET IsReleased = 1,
                                 ReleasedDate = @ReleasedDate,
                                 ReleasedByUserID = @ReleasedByUserID,
                                 ReleaseApplicationID = @ReleaseApplicationID
                             WHERE DetainedLicenseID = @DetainedLicenseID
                             AND IsReleased = 0";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainedLicenseID", DetainedLicenseID);
            Command.Parameters.AddWithValue("@ReleasedDate", ReleasedDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
                Connection.Dispose();
                Command.Dispose();
            }

            return RowsAffected > 0;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT CASE WHEN EXISTS
                             (
                                 SELECT 1
                                 FROM DetainedLicenses
                                 WHERE LicenseID = @LicenseID
                                 AND IsReleased = 0
                             )
                             THEN 1 ELSE 0 END";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                IsDetained = (int)Command.ExecuteScalar() == 1;
            }
            finally
            {
                Connection.Close();
                Connection.Dispose();
                Command.Dispose();
            }

            return IsDetained;
        }

        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM DetainedLicenses";

            SqlCommand Command = new SqlCommand(Query, Connection);
            SqlDataReader Reader = null;

            try
            {
                Connection.Open();
                Reader = Command.ExecuteReader();
                dt.Load(Reader);
            }
            finally
            {
                if (Reader != null)
                    Reader.Close();

                Connection.Close();
                Connection.Dispose();
                Command.Dispose();
            }

            return dt;
        }

        public static DataTable GetAllForLicense(int LicenseID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM DetainedLicenses
                             WHERE LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();
                Reader = Command.ExecuteReader();
                dt.Load(Reader);
            }
            finally
            {
                if (Reader != null)
                    Reader.Close();

                Connection.Close();
                Connection.Dispose();
                Command.Dispose();
            }

            return dt;
        }

        private static DataTable _GetAllForDisplay(int? LicenseID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"
                            SELECT
                                DL.DetainedLicenseID, DL.LicenseID,
                                DL.IsReleased, DL.DetainedDate, DL.ReleasedDate,
                            
                                -- Created By User
                                CreatorPerson.FirstName + ' ' + CreatorPerson.SecondName + ' ' +
                                ISNULL(CreatorPerson.ThirdName + ' ', '') +
                                CreatorPerson.LastName AS CreatedByUser,
                            
                                -- Released By User
                                ReleaserPerson.FirstName + ' ' + ReleaserPerson.SecondName + ' ' +
                                ISNULL(ReleaserPerson.ThirdName + ' ', '') +
                                ReleaserPerson.LastName AS ReleasedByUser,
                            
                                -- Driver Information
                                DriverPerson.NationalNo,
                            
                                DriverPerson.FirstName + ' ' + DriverPerson.SecondName + ' ' +
                                ISNULL(DriverPerson.ThirdName + ' ', '') +
                                DriverPerson.LastName AS DriverName,
                            
                                DL.FineFees, DL.ReleaseApplicationID
                            
                            FROM DetainedLicenses DL
                            
                            INNER JOIN Licenses L
                                ON L.LicenseID = DL.LicenseID
                            
                            INNER JOIN Drivers D
                                ON D.DriverID = L.DriverID
                            
                            INNER JOIN People DriverPerson
                                ON DriverPerson.PersonID = D.PersonID
                            
                            INNER JOIN Users CreatorUser
                                ON CreatorUser.UserID = DL.CreatedByUserID
                            
                            INNER JOIN People CreatorPerson
                                ON CreatorPerson.PersonID = CreatorUser.PersonID
                            
                            LEFT JOIN Users ReleaserUser
                                ON ReleaserUser.UserID = DL.ReleasedByUserID
                            
                            LEFT JOIN People ReleaserPerson
                                ON ReleaserPerson.PersonID = ReleaserUser.PersonID;";

            if (LicenseID.HasValue)
                Query += " WHERE DL.LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            if (LicenseID.HasValue)
                Command.Parameters.AddWithValue("@LicenseID", LicenseID.Value);

            SqlDataReader Reader = null;

            try
            {
                Connection.Open();
                Reader = Command.ExecuteReader();
                dt.Load(Reader);
            }
            finally
            {
                if (Reader != null)
                    Reader.Close();

                Connection.Close();
                Connection.Dispose();
                Command.Dispose();
            }

            return dt;
        }

        public static DataTable GetAllForDisplay()
        {
            return _GetAllForDisplay(null);
        }

        public static DataTable GetAllForDisplayForLicense(int LicenseID)
        {
            return _GetAllForDisplay(LicenseID);
        }
    }
}
