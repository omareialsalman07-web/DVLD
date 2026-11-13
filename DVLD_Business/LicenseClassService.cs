using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class LicenseClassService
    {
        public static LicenseClass Find(int id)
        {
            try
            {
                string className = string.Empty;
                string classDescription = string.Empty;
                byte minimumAllowedAge = 0;
                byte validityLength = 0;
                float classFees = 0;

                bool found = LicenseClassData.GetLicenseClassByID(
                    id,
                    ref className,
                    ref classDescription,
                    ref minimumAllowedAge,
                    ref validityLength,
                    ref classFees
                );

                if (!found)
                    return null;

                return new LicenseClass(
                    id,
                    className,
                    classDescription,
                    minimumAllowedAge,
                    validityLength,
                    classFees
                );

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
