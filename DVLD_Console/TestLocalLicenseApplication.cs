
using System;
using System.Collections.Generic;
using System.Data;
using DVLD_Business;

namespace DVLD_Console
{
    internal static class TestLocalLicenseApplication
    {
        internal static void PrintLocalLicenseApplication(
            LocalLicenseApplication localLicenseApplication)
        {
            if (localLicenseApplication == null)
            {
                Console.WriteLine("Local License Application not found.");
                return;
            }

            Console.WriteLine("------ Local License Application Card ------");
            Console.WriteLine("Local License Application ID : " +
                localLicenseApplication.LocalLicenseApplicationID);
            Console.WriteLine("Application ID               : " +
                localLicenseApplication.ApplicationID);
            Console.WriteLine("License Class ID             : " +
                localLicenseApplication.LicenseClassID);
            Console.WriteLine("Person ID                    : " +
                localLicenseApplication.PersonID);
            Console.WriteLine("---------------------------------------------");
        }

        internal static void TestCreateLocalLicenseApplication(
            int LicenseClassID,
            int PersonID,
            int CreatedByUserID)
        {
            Console.WriteLine("\n--- Testing Add New Local License Application ---");

            try
            {
                if (LocalLicenseApplicationService.Create(
                    LicenseClassID,
                    PersonID,
                    CreatedByUserID))
                {
                    Console.WriteLine(
                        "Local License Application added Successfully!");
                }
                else
                {
                    Console.WriteLine(
                        "Can't add Local License Application :-(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        internal static void TestGetAllLocalLicenseApplications()
        {
            Console.WriteLine(
                "\n--- Testing Get All Local License Applications ---");

            try
            {
                List<LocalLicenseApplication> applications =
                    LocalLicenseApplicationService
                    .GetAllLocalLicenseApplications();

                foreach (LocalLicenseApplication application in applications)
                {
                    PrintLocalLicenseApplication(application);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestGetLocalLicenseApplication(int ID)
        {
            Console.WriteLine(
                $"\n--- Testing Get Local License Application (ID: {ID}) ---");

            try
            {
                PrintLocalLicenseApplication(
                    LocalLicenseApplicationService.Find(ID));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestIsExistByID(int ID)
        {
            Console.WriteLine("\n--- Testing Exist By ID ---");

            try
            {
                LocalLicenseApplication application =
                    LocalLicenseApplicationService.Find(ID);

                if (application != null)
                {
                    Console.WriteLine(
                        $"Local License Application with ID {ID} exist!");
                }
                else
                {
                    Console.WriteLine(
                        $"Local License Application with ID {ID} Not exist! -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestGetAllLocalLicenseApplicationsForDisplay()
        {
            Console.WriteLine(
                "\n--- Testing Get All Local License Applications For Display ---");

            try
            {
                DataTable dt =
                    LocalLicenseApplicationService
                    .GetAllLocalLicenseApplicationsForDisplay();

                if (dt == null)
                {
                    Console.WriteLine("Can't retrieve data :-(");
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Application ID : " +
                        row["ApplicationID"]);
                    Console.WriteLine("Class Name     : " +
                        row["ClassName"]);
                    Console.WriteLine("Full Name      : " +
                        row["FullName"]);
                    Console.WriteLine("Status         : " +
                        row["Status"]);
                    Console.WriteLine("--------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestCompleteLocalLicenseApplication(int ID)
        {
            Console.WriteLine(
                "\n--- Testing Complete Local License Application ---");

            try
            {
                LocalLicenseApplication application =
                    LocalLicenseApplicationService.Find(ID);

                if (application == null)
                {
                    Console.WriteLine(
                        $"Local License Application with ID {ID} Not found -(!");
                    return;
                }

                if (LocalLicenseApplicationService.Complete(application))
                {
                    Console.WriteLine(
                        $"Local License Application with ID {ID} Completed!");
                }
                else
                {
                    Console.WriteLine(
                        $"Can't Complete Local License Application with ID {ID} -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestCancelLocalLicenseApplication(int ID)
        {
            Console.WriteLine(
                "\n--- Testing Cancel Local License Application ---");

            try
            {
                LocalLicenseApplication application =
                    LocalLicenseApplicationService.Find(ID);

                if (application == null)
                {
                    Console.WriteLine(
                        $"Local License Application with ID {ID} Not found -(!");
                    return;
                }

                if (LocalLicenseApplicationService.Cancle(application))
                {
                    Console.WriteLine(
                        $"Local License Application with ID {ID} Canceled!");
                }
                else
                {
                    Console.WriteLine(
                        $"Can't Cancel Local License Application with ID {ID} -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
    }
}
