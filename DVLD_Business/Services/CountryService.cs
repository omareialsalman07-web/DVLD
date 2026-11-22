using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public static class CountryService
    {
        public static Country Find(int ID)
        {
            Country country = null;
            string countryName = "";

            try
            {
                if (CountryData.GetCountryByID(ID, ref countryName))
                {
                    country = new Country(ID, countryName);
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return country;
        }
        public static List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();

            try
            {
                DataTable data = CountryData.GetAllCountries();
                foreach(DataRow row in data.Rows)
                {
                    Country country = new Country(Convert.ToInt32(row[0]), row[1].ToString());
                    countries.Add(country);
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return countries;
        }
        public static DataTable GetAllCountries_ToTable()
        {
            DataTable data = null;

            try
            {
                data = CountryData.GetAllCountries();
            }
            catch
            {
                data = null;
                throw;
            }

            return data;
        }
    }
}
