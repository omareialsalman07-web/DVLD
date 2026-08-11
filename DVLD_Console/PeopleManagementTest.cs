using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;

namespace DVLD_Console
{
    internal static class PeopleManagementTest
    {
        internal static void PrintPerson(Person person)
        {
            if (person == null)
            {
                Console.WriteLine("Person not found.");
                return;
            }

            Console.WriteLine("------------ Person Card -------------");
            Console.WriteLine("ID                     : " + person.ID);
            Console.WriteLine("First Name             : " + person.FirstName);
            Console.WriteLine("Second Name            : " + person.SecondName);
            Console.WriteLine("Third Name             : " + person.ThirdName);
            Console.WriteLine("Last Name              : " + person.LastName);
            Console.WriteLine("Birth of Date          : " + person.DateOfBirth.ToShortDateString());

            Console.WriteLine("Gender                 : " + person.Gendor);
            Console.WriteLine("Phone                  : " + person.Phone);
            Console.WriteLine("Email                  : " + person.Email);
            Console.WriteLine("Nationality Country ID : " + person.NationalityCountryID);
            Console.WriteLine("Image Path             : " + person.ImagePath);
            Console.WriteLine("--------------------------------------");
        }

        internal static void TestGetPerson(int personID)
        {
            try
            {
                Console.WriteLine($"\n--- Testing Get Person (ID: {personID}) ---");
                PrintPerson(PersonService.Find(personID));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestGetAllPeople()
        {
            try
            {
                Console.WriteLine("\n--- Testing Get All People ---");
                System.Data.DataTable dtPeople = PersonService.GetAllPeople_ToTable();

                if (dtPeople != null && dtPeople.Rows.Count > 0)
                {
                    Console.WriteLine($"Found {dtPeople.Rows.Count} person(s) in the database.\n");

                    // Print table headers
                    Console.WriteLine(string.Format("{0,-5} | {1,-12} | {2,-15} | {3,-15} | {4,-20}",
                        "ID", "NationalNo", "First Name", "Last Name", "Email"));
                    Console.WriteLine(new string('-', 75));

                    // Loop through rows and print details
                    foreach (System.Data.DataRow row in dtPeople.Rows)
                    {
                        Console.WriteLine(string.Format("{0,-5} | {1,-12} | {2,-15} | {3,-15} | {4,-20}",
                            row["PersonID"],
                            row["NationalNo"],
                            row["FirstName"],
                            row["LastName"],
                            row["Email"] == DBNull.Value ? "N/A" : row["Email"]
                        ));
                    }
                }
                else
                {
                    Console.WriteLine("No people found in the database or table is empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        internal static void TestGetAllPeople(PersonService.enFilter filterBy, string value)
        {
            try
            {
                Console.WriteLine("\n--- Testing Get All People Like " + filterBy.ToString() + " ---");
                System.Data.DataTable dtPeople = PersonService.GetAllPeople_ToTable(filterBy, value);

                if (dtPeople != null && dtPeople.Rows.Count > 0)
                {
                    Console.WriteLine($"Found {dtPeople.Rows.Count} person(s) in the database.\n");

                    // Print table headers
                    Console.WriteLine(string.Format("{0,-5} | {1,-12} | {2,-15} | {3,-15} | {4,-20}",
                        "ID", "NationalNo", "First Name", "Last Name", "Email"));
                    Console.WriteLine(new string('-', 75));

                    // Loop through rows and print details
                    foreach (System.Data.DataRow row in dtPeople.Rows)
                    {
                        Console.WriteLine(string.Format("{0,-5} | {1,-12} | {2,-15} | {3,-15} | {4,-20}",
                        row["PersonID"],
                        row["NationalNo"],
                        row["FirstName"],
                        row["LastName"],
                        row["Email"] == DBNull.Value ? "N/A" : row["Email"]
                        ));
                    }
                }
                else
                {
                    Console.WriteLine("No people found in the database or table is empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestAddNewPerson(string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, Person.enGendor gender, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            try
            {
                Console.WriteLine("\n--- Testing Add New Person ---");
                Person person = new Person(nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth, gender, address, phone, email, nationalityCountryID, imagePath);

                int id = PersonService.AddNewPerson(person);

                if (id != -1)
                {
                    Console.WriteLine($"Person added Successfully with ID = {id}!");
                }
                else
                {
                    Console.WriteLine("Can't add Person :-(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestIsExistByID(int personID)
        {
            try
            {
                Console.WriteLine($"\n--- Testing IsExist By ID ({personID}) ---");
                if (PersonService.isExist(personID))
                {
                    Console.WriteLine($"Person with ID : {personID} exists.");
                }
                else
                {
                    Console.WriteLine($"Person with ID : {personID} does NOT exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestIsExistByNationalNo(string nationalNo)
        {
            try
            {
                Console.WriteLine($"\n--- Testing IsExist By NationalNo ({nationalNo}) ---");
                if (PersonService.isExist(nationalNo))
                {
                    Console.WriteLine($"Person with NationalNo : {nationalNo} exists.");
                }
                else
                {
                    Console.WriteLine($"Person with NationalNo : {nationalNo} does NOT exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestUpdatePerson(int personID)
        {
            try
            {
                Console.WriteLine($"\n--- Testing Update Person (ID: {personID}) ---");
                Person person = PersonService.Find(personID);
                if (person == null)
                {
                    Console.WriteLine($"There is no person with ID {personID}");
                    return;
                }

                person.LastName = "TEST_UPDATED";
                person.Email = "updated_test@gmail.com";

                if (PersonService.UpdatePerson(person))
                {
                    Console.WriteLine("Updated Person Successfully!");
                }
                else
                {
                    Console.WriteLine("Can't Update Person!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        internal static void TestDeletePerson(int personID)
        {
            try
            {
                Console.WriteLine($"\n--- Testing Delete Person (ID: {personID}) ---");
                if (PersonService.DeletePerson(personID))
                {
                    Console.WriteLine("Deleted Person successfully!");
                }
                else
                {
                    Console.WriteLine("Can't Delete Person!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
    }
}