using DVLD_Business;
using DVLD_Presentation.Forms;
using DVLD_Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation
{
    public partial class ctrlPersonCard : UserControl
    {
        Person Person = null;

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadPerson(Person person)
        {
            if (person == null)
                return;

            Person = person;

            lbID.Text = Person.ID.ToString();
            lbFullName.Text = Person.FullName().ToString();
            lbNationalNo.Text = Person.NationalNo.ToString();
            lbGendor.Text = Person.Gendor.ToString();
            lbEmail.Text = Person.Email.ToString();
            lbAddress.Text = Person.Address.ToString();
            lbBirthOfDate.Text = Person.DateOfBirth.ToString();
            lbPhone.Text = Person.Phone.ToString();
            lbAge.Text = Person.Age().ToString();

            if (String.IsNullOrEmpty(Person.ImagePath))
            {
                switch (Person.Gendor)
                {
                    case Person.enGendor.Male:
                        PersonImage.Image = Resources.Male;
                        break;
                    case Person.enGendor.Female:
                        PersonImage.Image = Resources.Female;
                        break;
                }
            }
            else
            {
                PersonImage.Image?.Dispose();
                try
                {
                    // Load into a temporary image, create a cloned Bitmap, and close the file stream immediately
                    using (var tempImg = Image.FromFile(Person.ImagePath))
                    {
                        PersonImage.Image = new Bitmap(tempImg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try
            {
                lbCountry.Text = CountryService.Find(Person.NationalityCountryID).Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public bool LoadPerson(int personID)
        {
            Person = PersonService.Find(personID);
            if (Person == null)
                return false;

            _LoadPerson(Person);
            return true;
        }
        public void LoadPerson(Person person)
        {
            _LoadPerson(person);
        }

        private void _OnAddEditPersonClose(int personID)
        {
            try
            {
                Person = PersonService.Find(personID);
                _LoadPerson(Person);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lkbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPersonForm form = new AddEditPersonForm(AddEditPersonForm.enMode.eEdit, Person);
            form.on_Create_Update_PersonFinish += _OnAddEditPersonClose;
            form.ShowDialog();
        }

       
    }
}