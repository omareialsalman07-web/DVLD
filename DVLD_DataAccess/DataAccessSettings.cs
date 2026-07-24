using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    internal class DataAccessSettings
    {
        internal static string ConnectionString = 
            $"Server=.;Database=DVLD;Integrated Security=True;"; // Connection using window athurication and local server
    }
}
