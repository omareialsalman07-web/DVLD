using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class Person
    {
        public int ID { get; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public int Age()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public Person(string NationalNo, string FirstName,  string SecondName, string ThirdName, 
        string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, 
        int NationalityCountryID, string ImagePath)
        {
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
        }

        public Person(int ID, string NationalNo, string FirstName,  string SecondName, string ThirdName, 
        string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, 
        int NationalityCountryID, string ImagePath) 
            : this(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, 
                  Email, NationalityCountryID, ImagePath)
        {
            this.ID = ID;
        }
    }
}
