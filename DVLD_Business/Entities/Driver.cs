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
        public Person PersonInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public User CreatedByUserInfo { get; set; }

        public Driver(int personID,
            DateTime createdDate, int createdByUserID)
        {
            PersonInfo = PersonService.Find(personID);
            CreatedDate = createdDate;
            CreatedByUserInfo = UserService.FindByUserID(createdByUserID);
        }

        public Driver(int driverID, int personID,
            DateTime createdDate, int createdByUserID)
            :this(personID, createdDate, createdByUserID)
        {
            DriverID = driverID;
            
        }
    }
}