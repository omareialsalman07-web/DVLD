using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class PersonService
    {
        public enum enFilter { None, PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, NationalityCountryID,
        Gendor, Phone, Email }

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
        public static DataTable GetAllPeople_ToTable()
        {
            DataTable data = null;

            try
            {
                data = PersonData.GetAllPeople();
            }
            catch(Exception ex)
            {
                throw;
            }

            return data;
        }
        public static List<Person> GetAllPeople()
        {
            List<Person> peopleList = new List<Person>();

            DataTable data = GetAllPeople_ToTable();

            foreach (DataRow row in data.Rows)
            {
                Person person = new Person
                (
                    ID: Convert.ToInt32(row["PersonID"]),
                    NationalNo: row["NationalNo"]?.ToString(),
                    FirstName: row["FirstName"]?.ToString(),
                    SecondName: row["SecondName"]?.ToString(),
                    ThirdName: row["ThirdName"]?.ToString(),
                    LastName: row["LastName"]?.ToString(),
                    DateOfBirth: Convert.ToDateTime(row["DateOfBirth"]),
                    // Cast the raw database integer (0 or 1) directly to your enum type
                    Gendor: (Person.enGendor)Convert.ToInt32(row["Gendor"]),
                    Address: row["Address"]?.ToString(),
                    Phone: row["Phone"]?.ToString(),
                    Email: row["Email"]?.ToString(),
                    NationalityCountryID: Convert.ToInt32(row["NationalityCountryID"]),
                    ImagePath: row["ImagePath"]?.ToString()
                );

                peopleList.Add(person);
            }

            return peopleList;
        }
        public static DataTable GetAllPeople_ToTable(enFilter filterBy, string value)
        {
            if (filterBy == enFilter.None)
                return null;

            DataTable data = null;
            try
            {
                data = PersonData.GetAllPeople_Like(filterBy.ToString(), value);
            }
            catch (Exception ex)
            {
                throw;
            }

            return data;
        }
        public static List<Person> GetAllPeople(enFilter filterBy, string value)
        {
            List<Person> peopleList = new List<Person>();

            DataTable data = GetAllPeople_ToTable(filterBy, value);

            foreach (DataRow row in data.Rows)
            {
                Person person = new Person
                (
                    ID: Convert.ToInt32(row["PersonID"]),
                    NationalNo: row["NationalNo"]?.ToString(),
                    FirstName: row["FirstName"]?.ToString(),
                    SecondName: row["SecondName"]?.ToString(),
                    ThirdName: row["ThirdName"]?.ToString(),
                    LastName: row["LastName"]?.ToString(),
                    DateOfBirth: Convert.ToDateTime(row["DateOfBirth"]),
                    // Cast the raw database integer (0 or 1) directly to your enum type
                    Gendor: (Person.enGendor)Convert.ToInt32(row["Gendor"]),
                    Address: row["Address"]?.ToString(),
                    Phone: row["Phone"]?.ToString(),
                    Email: row["Email"]?.ToString(),
                    NationalityCountryID: Convert.ToInt32(row["NationalityCountryID"]),
                    ImagePath: row["ImagePath"]?.ToString()
                );

                peopleList.Add(person);
            }

            return peopleList;
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
        public static bool UpdatePerson(in Person person)
        {
            bool succeed = false;
            try
            {
                succeed = PersonData.UpdatePerson(person.ID, person.NationalNo, person.FirstName, person.SecondName,
                    person.ThirdName, person.LastName, person.DateOfBirth, (int)person.Gendor, person.Address,
                    person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);
            }
            catch(Exception ex)
            {
                succeed = false;
                throw;
            }

            return succeed;
        }
        public static bool DeletePerson(int ID)
        {
            bool succeed = false;
            try
            {
                succeed = PersonData.DeletePerson(ID);
            }
            catch(Exception ex)
            {
                succeed = false;
                throw;
            }

            return succeed;
        }
    }
}
