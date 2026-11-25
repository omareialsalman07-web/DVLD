
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_Business
{
    public static class DriverService
    {
        public static Driver FindByPersonID(int personID)
        {
            int driverID = -1;
            DateTime createdDate = DateTime.MinValue;
            int createdByUserID = -1;

            if (!DriverData.GetDriverByPersonID(personID, ref driverID, ref createdDate, ref createdByUserID))
            {
                return null;
            }

            return new Driver(driverID, personID, createdDate, createdByUserID);
        }

        public static Driver Find(int driverID)
        {
            int personID = -1;
            DateTime createdDate = DateTime.MinValue;
            int createdByUserID = -1;

            if (!DriverData.GetDriverByDriverID(driverID, ref personID, ref createdDate, ref createdByUserID))
            {
                return null;
            }

            return new Driver(driverID, personID, createdDate, createdByUserID);
        }

        internal static int Create(int personID, int createdByUserID)
        {
            if (FindByPersonID(personID) != null)
                throw new InvalidOperationException(
                    "This person is already registered as a driver.");

            return DriverData.CreateDriver(personID, DateTime.Today, createdByUserID);
        }

        public static int GetTotalAvailableLicenses(int driverID)
        {
            return LicenseData.GetTotalAvailableLicensesForDriver(driverID);
        }

        public static DataTable GetDrivers_ToTable()
        {
            return DriverData.GetDrivers();
        }
        public static List<Driver> GetDrivers()
        {
            List<Driver> driversList = new List<Driver>();

            DataTable data = DriverData.GetDrivers();
            foreach (DataRow row in data.Rows)
            {
                Driver driver = new Driver
                (
                    driverID: Convert.ToInt32(row["DriverInfo"]),
                    personID: Convert.ToInt32(row["PersonInfo"]),
                    createdDate: Convert.ToDateTime(row["CreatedDate"]),
                    createdByUserID: Convert.ToInt32(row["CreatedByUserInfo"])
                );

                driversList.Add(driver);
            }

            return driversList;
        }
        public static DataTable GetDriversForDisplay()
        {
            return DriverData.GetDriversForDisplay();
        }
    }
}
