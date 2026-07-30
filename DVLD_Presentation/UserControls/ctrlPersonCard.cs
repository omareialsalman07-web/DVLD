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
using DVLD_Presentation.Properties;

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
            lbAge.Text = person.Age().ToString();

            if(String.IsNullOrEmpty(person.ImagePath))
            {
                switch(person.Gendor)
                {
                    case Person.enGendor.Male:
                        pictureBox1.Image = Resources.Male;
                        break;
                    case Person.enGendor.Female:
                        pictureBox1.Image = Resources.Female;
                        break;
                }

                try
                {
                    lbCountry.Text = CountryService.Find(person.NationalityCountryID).Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}