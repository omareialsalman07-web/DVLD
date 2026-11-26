
using DVLD_DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

public class InternationalLicenseData
{
    public static bool Create(int LicenseID, int LocalLicenseID)
    {
        bool success = false;

        SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

        string query = @"INSERT INTO InternationalLicenses
                         (LicenseID, LocalLicenseID)
                         VALUES (@LicenseID, @LocalLicenseID);";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@LicenseID", LicenseID);
        command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

        try
        {
            connection.Open();

            success = command.ExecuteNonQuery() > 0;
        }
        catch (Exception ex)
        {
            success = false;
            throw ex;
        }
        finally
        {
            connection.Close();
            command.Dispose();
            connection.Dispose();
        }

        return success;
    }

    private static bool GetInternationalLicenseInfo(string ColumnName, int ID, ref int LicenseID, ref int LocalLicenseID)
    {
        bool IsFound = false;

        SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

        string query = $@"SELECT *
                          FROM InternationalLicenses
                          WHERE {ColumnName} = @ID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        SqlDataReader reader = null;

        try
        {
            connection.Open();

            reader = command.ExecuteReader();

            if (reader.Read())
            {
                IsFound = true;

                LicenseID = (int)reader["LicenseID"];

                LocalLicenseID = (int)reader["LocalLicenseID"];
            }
        }
        catch (Exception)
        {
            IsFound = false;
        }
        finally
        {
            if (reader != null)
                reader.Close();

            connection.Close();
            command.Dispose();
            connection.Dispose();
        }

        return IsFound;
    }

    
    public static bool GetByLicenseID(int LicenseID, ref int LocalLicenseID)
    {
        return GetInternationalLicenseInfo("LicenseID", LicenseID, ref LicenseID, ref LocalLicenseID);
    }

    public static bool GetByLocalLicenseID(int LocalLicenseID, ref int LicenseID)
    {
        return GetInternationalLicenseInfo("LocalLicenseID", LocalLicenseID, ref LicenseID, ref LocalLicenseID);
    }

    private static bool IsExist(string ColumnName, int ID)
    {
        bool IsFound = false;

        SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

        string query = $@"SELECT 1
                      FROM InternationalLicenses
                      WHERE {ColumnName} = @ID";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null)
                IsFound = true;
        }
        catch (Exception)
        {
            IsFound = false;
        }
        finally
        {
            connection.Close();
            command.Dispose();
            connection.Dispose();
        }

        return IsFound;
    }

    public static bool IsExistByInternationalID(int InternationalLicenseID)
    {
        return IsExist("LicenseID", InternationalLicenseID);
    }


    public static bool IsExistByLocalLicenseID(int LocalLicenseID)
    {
        return IsExist("LocalLicenseID", LocalLicenseID);
    }

    public static bool HasActiveLicese(int DriverID)
    {
        bool IsFound = false;

        SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

        string query = @"SELECT Found = 1 WHERE 
                        EXISTS
                        (
                        SELECT R='y' FROM InternationalLicenses
                        INNER JOIN Licenses ON InternationalLicenses.LicenseID = Licenses.LicenseID
                        WHERE Licenses.DriverID = @DriverID AND Licenses.IsActive = 1
                        );";

        SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@DriverID", DriverID);

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null)
                IsFound = true;
        }
        catch (Exception)
        {
            IsFound = false;
        }
        finally
        {
            connection.Close();
            command.Dispose();
            connection.Dispose();
        }

        return IsFound;
    }

    public static DataTable GetInternationalLicenses()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
        string query = @"SELECT * FROM InternationalLicenses;";

        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();

            dt.Load(command.ExecuteReader());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }

        return dt;
    }
    public static DataTable GetInternationalLicensesForDriver(int driverID)
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
        string query = @"SELECT InternationalLicenses.LicenseID, InternationalLicenses.LocalLicenseID
                         FROM InternationalLicenses
                         INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.LicenseID
                         WHERE Licenses.DriverID  = DriverID;";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@DriverID", driverID);

        try
        {
            connection.Open();

            dt.Load(command.ExecuteReader());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }

        return dt;
    }
    public static DataTable GetInternationalLicensesForDriver_ForDisplay(int driverID)
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
        string query = @"SELECT InternationalLicenses.LicenseID, Applications.ApplicationID,
                             InternationalLicenses.LocalLicenseID, Licenses.IssueDate, DATEADD(YEAR, 1, Licenses.IssueDate)
                             AS ExpirationDate, 
                                CAST
                                (
                                CASE
                                	WHEN Licenses.IsActive = 1 AND CAST(DATEADD(YEAR, 1, Licenses.IssueDate) AS DATE) >= CAST(GETDATE() AS DATE) THEN 1
                                	ELSE 0
                                END AS BIT
                                ) AS Active
                             FROM InternationalLicenses
                             INNER JOIN LocalLicenses ON LocalLicenses.LicenseID = InternationalLicenses.LocalLicenseID
                             INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.LicenseID
                             INNER JOIN Applications ON Applications.ApplicationID = Licenses.ApplicationID
                             WHERE Licenses.DriverID  = @DriverID;";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@DriverID", driverID);

        try
        {
            connection.Open();

            dt.Load(command.ExecuteReader());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }

        return dt;
    }
}
