using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;

namespace DVLD_Console
{
    internal static class UsersTest
    {
        public static void TestCreateUser(int PersonID, string UserName, string Password)
        {
            Console.WriteLine("\n--- Testing Add New User ---");

            User user = new User(PersonID, UserName, Password);
            try
            {
                int id = UserService.AddNewUser(user);
                if(id != -1)
                {
                    Console.WriteLine($"User added Successfully with ID = {id}!");
                }
                else
                {
                    Console.WriteLine("Can't add Person :-(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
    }
}
