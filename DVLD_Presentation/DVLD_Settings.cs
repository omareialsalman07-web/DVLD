using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Presentation
{
    internal static class DVLD_Settings
    {
        internal static string GetLocalDataPath()
        {
            string localDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            localDataPath = Path.Combine(localDataPath, "DVLD");
            Directory.CreateDirectory(localDataPath);

            return localDataPath;
        }
    }
}
