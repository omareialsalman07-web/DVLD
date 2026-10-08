using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Console
{
    internal static class ApplicationTypesTest
    {
        private static void _PrintApplicationType(in ApplicationType ap)
        {
            Console.WriteLine("Application Type Info : ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("ID    : " + ap.ID);
            Console.WriteLine("Title : " + ap.Title);
            Console.WriteLine("Fees  : " + ap.Fees);
            Console.WriteLine("----------------------------");
        }

        internal static void TestGetAllApplicationTypes()
        {
            Console.WriteLine("----- Testing get all applications ------");

            List<ApplicationType> applicationTypes = null;
            try
            {
                applicationTypes = ApplicationTypeService.GetAllApplictionTypes();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if(applicationTypes == null)
            {
                Console.WriteLine("Error : can't load applicition (the list is null)!");
                return;
            }

            for (int i = 0; i < applicationTypes.Count; i++)
            {
                _PrintApplicationType(applicationTypes[i]);
            }

        }

        internal static void TestUpdateApplicationInfo()
        {
            Console.WriteLine("----- Testing update application type ------");

            ApplicationType ap = new ApplicationType(1, "New Local Driving License Service", 15.00f);


            bool result = false;

            try
            {
                result = ApplicationTypeService.UpdateApplicationInfo(ap);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            if (result)
                Console.WriteLine("TEST PASSED: Application type updated successfully.");
            else
                Console.WriteLine("TEST FAILED: Application type was not updated.");
        }

    }
}
