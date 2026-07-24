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
                    person = new Person(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address,
                        Phone, Email, NationalityCountryID, ImagePath);
                }
            }
            catch
            {
                person = null;
                throw;
            }

            return person;
        }
    }
}
