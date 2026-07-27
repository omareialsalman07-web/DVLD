using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Console
{
    internal static class CountriesTest
    {
        private static void PrintCountry(in Country country)
        {
            if (country == null)
            {
                Console.WriteLine("Person not found.");
                return;
            }

            Console.WriteLine("------------ Country Card -------------");
            Console.WriteLine("ID     : " + country.ID);
            Console.WriteLine("Name   : " + country.Name);
            Console.WriteLine("--------------------------------------");
        }

        internal static void TestGetCountryByID(int countryID)
        {
            try
            {
                Country country = CountryService.Find(countryID);
                if(country != null)
                {
                    PrintCountry(country);
                }
                else
                {
                    Console.WriteLine("Can't find a country with ID : " + countryID);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
    }
}
