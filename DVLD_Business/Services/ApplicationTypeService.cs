using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public static class ApplicationTypeService
    {
        public static ApplicationType Find(int ID)
        {
            ApplicationType applicationType = null;
            try
            {
                string Title = "";
                float Fees = 0;
                if(ApplicationTypeData.GetApplicationType(ID, ref Title, ref Fees))
                {
                    applicationType = new ApplicationType(ID, Title, Fees);
                }
            }
            catch(Exception ex)
            {
                applicationType = null;
                throw;
            }

            return applicationType;
        }

        public static DataTable GetAllApplictionTypes_ToTable()
        {
            DataTable dt = null;

            try
            {
                dt = ApplicationTypeData.GetAllApplicationTypes();
            }
            catch(Exception ex)
            { 
                dt = null; 
                throw; 
            }

            return dt;
        }

        public static List<ApplicationType> GetAllApplictionTypes()
        {
            List<ApplicationType> applicationTypes = new List<ApplicationType>();

            DataTable dt = null;
            try
            {
                dt = ApplicationTypeData.GetAllApplicationTypes();
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }

            if (dt == null) return null;

            foreach(DataRow row in dt.Rows)
            {
                applicationTypes.Add(new ApplicationType(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToSingle(row[2])));
            }

            return applicationTypes;
        }

        public static bool UpdateApplicationInfo(in ApplicationType ap)
        {
            bool success = false;
            try
            {
                success = ApplicationTypeData.UpdateApplicationInfo(ap.ID, ap.Title, ap.Fees);
            }
            catch(Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }

        public static bool UpdateApplicationInfo(int ID, string Title, float Fees)
        {
            bool success = false;
            try
            {
                success = ApplicationTypeData.UpdateApplicationInfo(ID, Title, Fees);
            }
            catch(Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
    }
}
