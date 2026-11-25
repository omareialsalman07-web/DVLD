using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public static class UserService
    {
        public enum enFilter { None, UserID, PersonID, FullName, UserName, IsActive };

        public static int AddNewUser(in User user)
        {
            int _id = -1;

            try
            {
                User u = FindByPersonID(user.PersonInfo.ID);
                if (u != null)
                    throw new Exception($"This Person already has a user with user name : [{u.UserName}]");

                _id = UserData.AddNewUser(user.PersonInfo.ID, user.UserName, user.Password, user.IsActive);
            }
            catch (Exception ex)
            {
                _id = -1;
                throw;
            }

            return _id;
        }
        public static DataTable GetAllUserToTable()
        {
            DataTable dt = null;

            try
            {
                dt = UserData.GetAllUser();
            }
            catch(Exception ex)
            {
                dt = null;
                throw;
            }

            return dt;
        }
        public static List<User> GetAllUser()
        {
            List<User> usersList = new List<User>();

            DataTable data = UserData.GetAllUser();

            foreach (DataRow row in data.Rows)
            {
                User user = new User
                (
                    UserID: Convert.ToInt32(row["UserID"]),
                    PersronID: Convert.ToInt32(row["PersonInfo"]),
                    UserName: row["UserName"].ToString(),
                    Password: row["Password"].ToString(),
                    IsActive: Convert.ToBoolean(row["IsActive"])
                );

                usersList.Add(user);
            }

            return usersList;
        }
        public static DataTable GetAllUsersForDisplay()
        {
            DataTable dt = null;

            try
            {
                dt = UserData.GetAllUsersForDisplay();
            }
            catch(Exception ex)
            {
                dt = null;
                throw;
            }

            return dt;
        }
        public static DataTable GetAllUsersForDisplay_Like(enFilter filter, string val)
        {
            DataTable dt = null;

            try
            {
                if(filter == enFilter.None)
                    dt = UserData.GetAllUsersForDisplay();
                else
                    dt = UserData.GetAllUsersForDisplay_Like(filter.ToString(), val);
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }

            return dt;
        }
        public static User FindByUserID(int userID)
        {
            User user = null;

            int personID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;

            try
            {
                if (UserData.GetUserByUserID(userID, ref personID, ref userName, ref password, ref isActive))
                {
                    user = new User(userID, personID, userName, password, isActive);
                }
                else
                    user = null;
            }
            catch (Exception ex)
            {
                user = null;
                throw;
            }

            return user;
        }
        public static User FindUserName(string userName)
        {
            User user = null;

            int userID = -1;
            int personID = -1;
            string password = "";
            bool isActive = false;

            try
            {
                if (UserData.GetUserByUserName(userName, ref userID, ref personID, ref password, ref isActive))
                {
                    user = new User(userID, personID, userName, password, isActive);
                }
                else
                    user = null;
            }
            catch (Exception ex)
            {
                user = null;
                throw;
            }

            return user;
        }
        public static User FindByPersonID(int personID)
        {
            User user = null;

            int userID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;

            try
            {
                if (UserData.GetUserByPersonID(personID, ref userID, ref userName, ref password, ref isActive))
                {
                    user = new User(userID, personID, userName, password, isActive);
                }
                else
                    user = null;
            }
            catch (Exception ex)
            {
                user = null;
                throw;
            }

            return user;
        }
        public static bool UpdateUser(in User user)
        {
            bool success = false;

            try
            {
                success = UserData.UpdateUser(user.ID, user.PersonInfo.ID, user.UserName, user.Password, user.IsActive);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
        public static bool isExistByUserID(int ID)
        {
            bool success = false;

            try
            {
                success = UserData.isExistByUserID(ID);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
        public static bool isExistByUserName(string userName)
        {
            bool success = false;

            try
            {
                success = UserData.isExistByUserName(userName);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
        public static bool isExistByPersonID(int personID)
        {
            bool success = false;

            try
            {
                success = UserData.isExistByPersonID(personID);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
        public static bool DeleteUser(int id)
        {
            bool success = false;

            try
            {
                success = UserData.DeleteUser(id);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
        public static bool SetActive(int userID, bool val)
        {
            bool success = false;

            try
            {
                success = UserData.SetActive(userID, val);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
    }
}