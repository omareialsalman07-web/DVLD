using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class Country
    {
        public int ID{ get; }
        public string Name { get; set; }

        public Country(string Name)
        {
            this.Name = Name;
        }
        public Country(int ID, string Name) : this(Name)
        {
            this.ID = ID;
        }
    }
}
