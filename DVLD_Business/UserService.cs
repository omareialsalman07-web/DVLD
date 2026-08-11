using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class UserService
    {
        public static int AddNewUser(in User user)
        {
            int _id = -1;

            try
            {
                _id = UserData.AddNewUser(user.PersonID, user.UserName, user.Password);
            }
            catch(Exception ex)
            {
                _id = -1;
                throw;
            }

            return _id;
        }
    }
}
