
using DVLD_DataAccess;
using System;

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
    }
}
