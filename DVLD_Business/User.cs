using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class User
    {
        public int UserID { get; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public User(int PersonID, string UserName, string Password)
        {
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
        }

        public User(int UserID, int PersronID, string UserName, string Password) : this(PersronID, UserName, Password)
        {
            this.UserID = UserID;
        }
    }
}
