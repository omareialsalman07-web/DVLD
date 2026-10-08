using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Console
{
    internal static class TestTypesTest
    {
        private static void _PrintTestType(in TestType testType)
        {
            Console.WriteLine("Test Type Info : ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("ID    : " + testType.ID);
            Console.WriteLine("Title : " + testType.Title);
            Console.WriteLine("Descreption : " + testType.Description);
            Console.WriteLine("Fees  : " + testType.Fees);
            Console.WriteLine("----------------------------");
        }

        internal static void TestGetAllTestTypes()
        {
            Console.WriteLine("----- Testing get all Test Types ------");

            List<TestType> TestTypes = null;
            try
            {
                TestTypes = TestTypeService.GetAllTestTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (TestTypes == null)
            {
                Console.WriteLine("Error : can't load applicition (the list is null)!");
                return;
            }

            for (int i = 0; i < TestTypes.Count; i++)
            {
                _PrintTestType(TestTypes[i]);
            }

        }

        internal static void TestGetTestType()
        {
            Console.WriteLine("----- Testing get Test Type ------");

            TestType TestType = null;
            try
            {
                TestType = TestTypeService.Find(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (TestType == null)
            {
                Console.WriteLine("Error : can't load applicition (the list is null)!");
                return;
            }

            _PrintTestType(TestType);
        }

        internal static void TestUpdateTestInfo()
        {
            Console.WriteLine("----- Testing update Test type ------");

            TestType testType = new TestType(1, "Test", "Test", 15.00f);


            bool result = false;

            try
            {
                result = TestTypeService.UpdateTestInfo(testType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            if (result)
                Console.WriteLine("TEST PASSED: Test type updated successfully.");
            else
                Console.WriteLine("TEST FAILED: Test type was not updated.");
        }

    }
}

/*
 
Vision Test	
This assesses the applicant's visual acuity to ensure they meet the required vision standards for driving safely.
 
 */