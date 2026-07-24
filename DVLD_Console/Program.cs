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

        static void testGetPerson(int id)
        {
            try
            {
                PrintPerson(PersonService.Find(id));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }

        static void Main(string[] args)
        {
            testGetPerson(1);
            Console.ReadLine();
        }
    }
}
