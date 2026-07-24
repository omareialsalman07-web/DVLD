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
        static void PrintPerson(in Person person)
        {
            if (person == null)
                return;

            Console.WriteLine("------------Person Card --------- ");
            Console.WriteLine("ID                     : " + person.ID);
            Console.WriteLine("First Name             : " + person.FirstName);
            Console.WriteLine("Seconed Name           : " + person.SecondName);
            Console.WriteLine("Third Name             : " + person.ThirdName);
            Console.WriteLine("Last Name              : " + person.LastName);
            Console.WriteLine("Birth of Date          : " + person.DateOfBirth);
            Console.WriteLine("Gendor                 : " + person.Gendor);
            Console.WriteLine("Phone                  : " + person.Phone);
            Console.WriteLine("Email                  : " + person.Email);
            Console.WriteLine("Nationality Country ID : " + person.NationalityCountryID);
            Console.WriteLine("Image Path             : " + person.ImagePath);
        }
        static void testGetPerson()
        {
            try
            {
                PrintPerson(PersonService.Find(1));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        static void testAddNewPerson()
        {
            try
            {
                Person person = new Person("N8", "Mohamad", "Maher", "Fadi", "Al-Mamhor", new DateTime(2001, 1, 12),
                    Person.enGendor.Male, "Amman-am", "0778978856", "mohad@gmail.com", 2, "");

                int id = PersonService.AddNewPerson(person);
                Console.WriteLine(id);

                if (id != -1)
                {
                    Console.WriteLine("Person added Successfully!");
                }
                else
                {
                    Console.WriteLine("Can't add Person -(");
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        static void testIsExistByID()
        {
            try
            {
                if(PersonService.isExist(1))
                {
                    Console.WriteLine("Peron with ID : 1 is exist");
                }
                else
                {
                    Console.WriteLine("Peron with ID : 1 is NOT exist");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        static void testIsExistByNationNo()
        {
            try
            {
                if (PersonService.isExist("N1"))
                {
                    Console.WriteLine("Peron with NationalNo : N1 is exist");
                }
                else
                {
                    Console.WriteLine("Peron with NationalNo : N1 is NOT exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        static void Main(string[] args)
        {
            //testGetPerson();
            //testAddNewPerson();
            //testIsExistByID();
            testIsExistByNationNo();
            Console.ReadLine();
        }
    }
}
