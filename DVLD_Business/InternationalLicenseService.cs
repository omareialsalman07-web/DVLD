using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public static class InternationalLicenseService
    {
        public static InternationalLicense FindByInternationalID(int InternationalLicenseID)
        {
            int licenseID = -1;
            int locallicenseID = -1;

            if (!InternationalLicenseData.GetByInternationalID(InternationalLicenseID, ref licenseID, ref locallicenseID))
            {
                return null;
            }

            return new InternationalLicense(InternationalLicenseID, locallicenseID, licenseID);
        }
        public static InternationalLicense FindByLicenseID(int licenseID)
        {
            int InternationallicenseID = -1;
            int localLicenseID = -1;

            if (!InternationalLicenseData.GetByLicenseID(licenseID, ref InternationallicenseID, ref localLicenseID))
            {
                return null;
            }

            return new InternationalLicense(InternationallicenseID, localLicenseID, licenseID);
        }
        public static InternationalLicense FindByLocalLicenseID(int localLicenseID)
        {
            int InternationallicenseID = -1;
            int licenseID = -1;

            if (!InternationalLicenseData.GetByLocalLicenseID(localLicenseID, ref InternationallicenseID, ref licenseID))
            {
                return null;
            }

            return new InternationalLicense(InternationallicenseID, localLicenseID, licenseID);
        }

        public static int Create(int LocalLicenseID, int CreatedByUserID)
        {
            LocalLicense localLicense = LocalLicenseService.FindByLocalLicenseID(LocalLicenseID);
            if (localLicense == null)
                throw new Exception($"Can't find Local License with ID [{LocalLicenseID}].");

            if (localLicense.LicenseClassID != 3)
                throw new Exception($@"Can't create International License with License Class [{LicenseClassService.Find(localLicense.LicenseClassID).ClassName}].
                                       The only allowed Class is {LicenseClassService.Find(3).ClassName}");

            if (IsExistByLocalLicenseID(localLicense.LocalLicenseID))
                throw new Exception($"This driver already has International License with ID [{FindByLocalLicenseID(localLicense.LocalLicenseID).InternationalLicenseID}].");

            int _ApplicationID = ApplicationData.CreateApplication((int)enApplicationType.eNewInternationalLicense, DateTime.Today,
                (int)enApplicationStatus.eNew, ApplicationTypeService.Find((int)enApplicationType.eNewInternationalLicense).Fees, CreatedByUserID);
            if(_ApplicationID == -1)
                throw new Exception($"Failed to Create Application with type ['{enApplicationType.eNewInternationalLicense}'].");

            Application application = ApplicationService.Find(_ApplicationID);

            if (application.Status == enApplicationStatus.eCancelled)
                throw new Exception($"Failed to Issue International License in canceled Application with ID [{application.ApplicationID}].");

            if (application.Status == enApplicationStatus.eCompleted)
                throw new Exception($"Failed to Issue International License in completed Application with ID [{application.ApplicationID}].");

            if(application.Type != enApplicationType.eNewInternationalLicense)
                throw new Exception($"Can't create International License with Application Type [{application.Type.ToString()}].");

            int driverID = LicenseService.FindByLicenseID(localLicense.LicenseID).DriverID;
            int licenseID = LicenseService.Create(enLicenseIssueType.eFirstTime, driverID, _ApplicationID, CreatedByUserID);
            if (licenseID == -1)
                throw new Exception("Failed to create license.");

            int result = InternationalLicenseData.Create(licenseID, localLicense.LocalLicenseID);
            if (result != -1)
                ApplicationService.Complete(_ApplicationID);

            return result;
        }

        public static bool IsExistByLocalLicenseID(int LocallLicenseID)
        {
            return InternationalLicenseData.IsExistByLocalLicenseID(LocallLicenseID);
        }
        public static bool IsExistByInternationalID(int InternationalLicenseID)
        {
            return InternationalLicenseData.IsExistByInternationalID(InternationalLicenseID);
        }

        public static List<InternationalLicense> GetInternationalLicenses()
        {
            List<InternationalLicense> InternationalLicensesList = new List<InternationalLicense>();

            DataTable data = InternationalLicenseData.GetInternationalLicenses();
            foreach (DataRow row in data.Rows)
            {
                InternationalLicense driver = new InternationalLicense
                (
                    internationalLicenseID: Convert.ToInt32(row["InternationalLicenseID"]),
                    localLicenseID: Convert.ToInt32(row["LicenseClassID"]),
                    licenseID: Convert.ToInt32(row["LicenseID"])
                );

                InternationalLicensesList.Add(driver);
            }

            return InternationalLicensesList;
        }
        public static List<InternationalLicense> GetInternationalLicensesForDriver(int driverID)
        {
            List<InternationalLicense> internationalLicensesList = new List<InternationalLicense>();

            DataTable data = InternationalLicenseData.GetInternationalLicensesForDriver(driverID);
            foreach (DataRow row in data.Rows)
            {
                InternationalLicense internationalLicense = new InternationalLicense
                (
                    internationalLicenseID: Convert.ToInt32(row["InternationalLicense"]),
                    localLicenseID: Convert.ToInt32(row["InternationalLicenseID"]),
                    licenseID: Convert.ToInt32(row["LicenseID"])
                );

                internationalLicensesList.Add(internationalLicense);
            }

            return internationalLicensesList;
        }
        public static DataTable GetInternationalLicensesForDriver_ForDisplay(int driverID)
        {
            return InternationalLicenseData.GetInternationalLicensesForDriver_ForDisplay(driverID);
        }
    }
}
