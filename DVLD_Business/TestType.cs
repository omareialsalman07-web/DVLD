using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class TestType
    {
        public int ID { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public TestType(string Title, string Description, float Fees)
        {
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }
        public TestType(int ID, string Title, string Description, float Fees) : this(Title, Description, Fees)
        {
            this.ID = ID;
        }
    }
}
