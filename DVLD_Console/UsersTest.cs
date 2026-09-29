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
        internal static void PrintUser(User user)
        {
            if (user == null)
            {
                Console.WriteLine("Person not found.");
                return;
            }

            Console.WriteLine("------------ Person Card -------------");
            Console.WriteLine("User ID                : " + user.ID);
            Console.WriteLine("Person ID              : " + user.PersonID);
            Console.WriteLine("User Name              : " + user.UserName);
            Console.WriteLine("Password               : " + user.Password);
            Console.WriteLine("Is Active              : " + user.IsActive.ToString());
            Console.WriteLine("--------------------------------------");
        }
        internal static void TestCreateUser(int PersonID, string UserName, string Password, bool isActive)
        {
            Console.WriteLine("\n--- Testing Add New User ---");

            User user = new User(PersonID, UserName, Password, isActive);
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
        internal static void TestGetAllUsers()
        {
            Console.WriteLine("\n--- Testing Get All User ---");

            try
            {
                List<User> users = UserService.GetAllUser();

                foreach(User user in users)
                {
                    PrintUser(user);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        internal static void TestGetPerson(int userID)
        {
            try
            {
                Console.WriteLine($"\n--- Testing Get Person (ID: {userID}) ---");
                PrintUser(UserService.Find(userID));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        internal static void TestIsExistByID(int ID)
        {
            Console.WriteLine("\n--- Testing Exist By ID ---");

            try
            {
                if(UserService.isExist(ID))
                {
                    Console.WriteLine($"User with ID {ID} exist!");
                }
                else
                {
                    Console.WriteLine($"User with ID {ID} Not exist! -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());

            }
        }
        internal static void TestIsExistByUserName(string userName)
        {
            Console.WriteLine("\n--- Testing Exist By User Name ---");

            try
            {
                if (UserService.isExist(userName))
                {
                    Console.WriteLine($"User with ID {userName} exist!");
                }
                else
                {
                    Console.WriteLine($"User with ID {userName} Not exist! -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());

            }
        }
        internal static void TestUpdateUser(int ID)
        {
            Console.WriteLine("\n--- Testing Update User ---");

            try
            {
                User user = UserService.Find(ID);
                if(user == null)
                {
                    Console.WriteLine($"User with ID {ID} Not found -(!");
                    return;
                }

                user.UserName = "UPDATED";

                if (UserService.UpdateUser(user))
                {
                    Console.WriteLine($"User with ID {ID} Updated!");
                }
                else
                {
                    Console.WriteLine($"User with ID {ID} Not exist! -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());

            }


        }
        internal static void TestDeleteUser(int ID)
        {
            Console.WriteLine("\n--- Testing Delting User ---");

            try
            {
                if (UserService.DeleteUser(ID))
                {
                    Console.WriteLine($"Deleted User with ID {ID} !");
                }
                else
                {
                    Console.WriteLine($"Can't delte user with ID {ID} -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());

            }
        }
        internal static void TestSetActive(int userID, bool val)
        {
            Console.WriteLine("\n--- Testing Delting User ---");

            try
            {
                if (UserService.SetActive(userID, val))
                {
                    Console.WriteLine($"Set Activation of User with ID {userID} to {val.ToString()} !");
                }
                else
                {
                    Console.WriteLine($"Can't change the activation of user with ID {userID} -(");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
    }
}
