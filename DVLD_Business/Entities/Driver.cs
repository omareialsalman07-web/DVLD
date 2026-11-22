using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class Driver
    {
        public int DriverID { get; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }

        public Driver(int personID,
            DateTime createdDate, int createdByUserID)
        {
            PersonID = personID;
            CreatedDate = createdDate;
            CreatedByUserID = createdByUserID;
        }

        public Driver(int driverID, int personID,
            DateTime createdDate, int createdByUserID)
            :this(personID, createdDate, createdByUserID)
        {
            DriverID = driverID;
            
        }
    }
}