using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD_Presentation
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPerson(int personID)
        {
            Person person = PersonService.Find(personID);
            if (person == null)
                return;

            lbID.Text = person.ID.ToString();
            lbFullName.Text = person.FullName().ToString();
            lbNationalNo.Text = person.NationalNo.ToString();
            lbGendor.Text = person.Gendor.ToString();
            lbEmail.Text = person.Email.ToString();
            lbAddress.Text = person.Address.ToString();
            lbBirthOfDate.Text = person.DateOfBirth.ToString();
            lbPhone.Text = person.Phone.ToString();
            lbCountry.Text = person.NationalityCountryID.ToString();
            lbAge.Text = person.Age().ToString();
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}