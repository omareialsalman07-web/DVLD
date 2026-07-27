using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
