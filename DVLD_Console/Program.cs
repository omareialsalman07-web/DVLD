using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;

namespace DVLD_Console
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //PeopleManagementTest.TestIsExistByID(1);
            //PeopleManagementTest.TestGetPerson(1);
            /*PeopleManagementTest.TestAddNewPerson(
                "N99", "Ali", "Khaled", "Sami", "Hassan",
                new DateTime(1998, 5, 20), Person.enGendor.Male,
                "Irbid", "0791111111", "ali@mail.com", 1, ""
            );*/
            //PeopleManagementTest.TestIsExistByID(1);
            //PeopleManagementTest.TestIsExistByNationalNo("N1");
            //PeopleManagementTest.TestUpdatePerson(2);
            //PeopleManagementTest.TestDeletePerson(2);
            //PeopleManagementTest.TestGetAllPeople();

            CountriesTest.TestGetCountryByID(90);


            Console.ReadLine();
        }
    }
}
