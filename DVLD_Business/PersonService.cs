using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class PersonService
    {
        public static Person Find(int ID)
        {
            Person person = null;

            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "",
                Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth= DateTime.Now;  
            int Gendor = -1, NationalityCountryID = -1;

            try
            {
                if(PersonData.GetPersonByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                    ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                {
                    person = new Person(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                        (Person.enGendor)Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
                }
            }
            catch
            {
                person = null;
                throw;
            }

            return person;
        }
        public static int AddNewPerson(in Person person)
        {
            if (person == null)
                return -1;

            int personId = -1;
            try
            {
                personId = PersonData.AddNewPerson(person.NationalNo, person.FirstName, person.SecondName, person.ThirdName,
                person.LastName, person.DateOfBirth, (int)person.Gendor, person.Address, person.Phone, person.Email,
                person.NationalityCountryID, person.ImagePath);
            }
            catch (Exception ex)
            {
                throw;
            }

            return personId;
        }
        public static bool isExist(int ID)
        {
            bool found = false;
            try
            {
                found = PersonData.isExist(ID);
            }
            catch(Exception ex)
            {
                throw;
            }
            return found;
        }
        public static bool isExist(string nationalNo)
        {
            bool found = false;
            try
            {
                found = PersonData.isExist(nationalNo);
            }
            catch(Exception ex)
            {
                throw;
            }
            return found;
        }
    }
}
