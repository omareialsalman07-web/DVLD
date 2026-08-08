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
using DVLD_Presentation.Forms;
using DVLD_Presentation.Properties;

namespace DVLD_Presentation
{
    public partial class ctrlPersonCard : UserControl
    {
        Person Person = null;
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPerson(int personID)
        {
            Person = PersonService.Find(personID);
            if (Person == null)
                return;

            lbID.Text = Person.ID.ToString();
            lbFullName.Text = Person.FullName().ToString();
            lbNationalNo.Text = Person.NationalNo.ToString();
            lbGendor.Text = Person.Gendor.ToString();
            lbEmail.Text = Person.Email.ToString();
            lbAddress.Text = Person.Address.ToString();
            lbBirthOfDate.Text = Person.DateOfBirth.ToString();
            lbPhone.Text = Person.Phone.ToString();
            lbAge.Text = Person.Age().ToString();

            if(String.IsNullOrEmpty(Person.ImagePath))
            {
                switch(Person.Gendor)
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
                    lbCountry.Text = CountryService.Find(Person.NationalityCountryID).Name;
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

        private void lkbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new AddEditPersonForm(AddEditPersonForm.enMode.eEdit, Person);
            form.ShowDialog();
        }
    }
}