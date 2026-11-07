using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public static class LocalLicenseApplicationService
    {
        public static bool Create(int LicenseClassID, int PersonID, int CreatedByUserID)
        {
            bool success = false;
            try
            {
                int result = LocalLicenseApplicationData.CreateLocalLicenseApplication(LicenseClassID, PersonID, CreatedByUserID);
                success = result != -1;
            }
            catch(Exception ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        public static LocalLicenseApplication Find(int localLicenseApplicationID)
        {
            LocalLicenseApplication lla = null;
            try
            {
                int _ApplicationID = 0, _LicenseClassID = 0, _PersonID = 0;
                if (LocalLicenseApplicationData.GetLocalLicenseApplicationByID(localLicenseApplicationID,
                    ref _ApplicationID, ref _LicenseClassID, ref _PersonID))
                {
                    lla = new LocalLicenseApplication(localLicenseApplicationID, _ApplicationID, _LicenseClassID, _PersonID);
                }
            }
            catch(Exception ex)
            {
                lla = null;
                throw ex;
            }

            return lla;
        }
        public static List<LocalLicenseApplication> GetAllLocalLicenseApplications()
        {
            List<LocalLicenseApplication> LocalLicenseApplicationsList = new List<LocalLicenseApplication>();

            DataTable data = LocalLicenseApplicationData.GetAllLocalLicenseApplications();

            foreach (DataRow row in data.Rows)
            {
                LocalLicenseApplication LocalLicenseApplication = new LocalLicenseApplication
                (
                    LocalLicenseApplicationID: Convert.ToInt32(row["LocalLicenseApplicationID"]),
                    ApplicationID: Convert.ToInt32(row["ApplicationID"]),
                    LicenseClassID: Convert.ToInt32(row["LicenseClassID"]),
                    PersonID: Convert.ToInt32(row["PersonID"])
                );

                LocalLicenseApplicationsList.Add(LocalLicenseApplication);
            }

            return LocalLicenseApplicationsList;
        }

        public static DataTable GetAllLocalLicenseApplicationsForDisplay()
        {
            DataTable dt = null;

            try
            {
                dt = LocalLicenseApplicationData.GetAllLocalLicenseApplications_ForDisplay();
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }

            return dt;
        }
        public static bool Complete(int localLicenseApplicationID)
        {
            bool success = false;
            try
            {
                success = LocalLicenseApplicationData.CompleteLocalLicenseApplication(localLicenseApplicationID);
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        public static bool Complete(in LocalLicenseApplication localLicenseApplication)
        {
            return Complete(localLicenseApplication.LocalLicenseApplicationID);
        }
        public static bool Cancle(int localLicenseApplicationID)
        {
            bool success = false;
            try
            {
                success = LocalLicenseApplicationData.CancleLocalLicenseApplication(localLicenseApplicationID);
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        public static bool Cancle(in LocalLicenseApplication localLicenseApplication)
        {
            return Cancle(localLicenseApplication.LocalLicenseApplicationID);
        }
    }
}
