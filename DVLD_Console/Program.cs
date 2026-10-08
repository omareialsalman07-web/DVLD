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
            //PeopleManagementTest.TestGetAllPeople(PersonService.enFilter.NationalityCountryID, "90");

            //CountriesTest.testGetCountryByID(90);
            //CountriesTest.testGetAllCountries();

            //UsersTest.TestCreateUser(1007, "Yz", "1234", true);
            ///UsersTest.TestSetActive(1, true);
            //UsersTest.TestGetPerson(1);
            //UsersTest.TestIsExistByUserName("Yz");
            //UsersTest.TestIsExistByID(1);
            //UsersTest.TestUpdateUser(1);
            //UsersTest.TestDeleteUser(1);
            //UsersTest.TestGetAllUsers();

            ApplicationTypesTest.TestUpdateApplicationInfo();
            ApplicationTypesTest.TestGetAllApplicationTypes();

            Console.ReadLine();
        }
    }
}
