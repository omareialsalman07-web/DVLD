using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;

namespace DVLD_Presentation
{
    internal static class DVLD_Settings
    {
        private static User CurrentUser;

        internal static string GetLocalDataPath()
        {
            string localDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            localDataPath = Path.Combine(localDataPath, "DVLD");
            Directory.CreateDirectory(localDataPath); // If already existed nothing happen

            return localDataPath;
        }

        internal static string GetPeoplePicturePath()
        {
            // path for images
            string peoplePath = Path.Combine(GetLocalDataPath(), "People");
            Directory.CreateDirectory(peoplePath); // If already existed nothing happen

            return peoplePath;
        }

        public static User GetCurrnetUser() { return CurrentUser; }

        public static void Login(User user)
        {
            if (CurrentUser != null)
                throw new InvalidOperationException("A user is already logged in.");

            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
