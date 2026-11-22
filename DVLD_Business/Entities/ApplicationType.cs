using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class ApplicationType
    {
        public int ID { get; }
        public string Title { get; set; }
        public float Fees { get; set; }

        public ApplicationType(string Title, float Fees)
        {
            this.Title = Title;
            this.Fees = Fees;
        }
        public ApplicationType(int ID, string Title, float Fees) : this(Title, Fees)
        {
            this.ID = ID;
        }
    }
}
