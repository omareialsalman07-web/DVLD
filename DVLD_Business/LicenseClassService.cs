using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class LicenseClassService
    {
        public static LicenseClass GetLicenseClassByID(int id)
        {
            try
            {
                return LicenseClass.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAllLicenseClasses()
        {
            try
            {
                return LicenseClassData.GetAllLicenseClasses();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
