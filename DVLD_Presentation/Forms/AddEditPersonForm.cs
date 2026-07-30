using DVLD_Business;
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

namespace DVLD_Presentation.Forms
{
    public partial class AddEditPersonForm : Form
    {
        public enum enMode { eAddNew, eEdit }
        enMode _Mode;

        string _ImagePath = null;
        Person PersonToEdit = null;
        public AddEditPersonForm(enMode mode, Person personToEdit = null)
        {
            InitializeComponent();
            _Mode = mode;
            
            if(_Mode == enMode.eEdit)
                PersonToEdit = personToEdit;
        }

        private void loadCountries()
        {
            DataTable dtCountries = CountryService.GetAllCountries_ToTable();

            cbCountries.DataSource = dtCountries;
            cbCountries.DisplayMember = "CountryName"; // The column name you want to show in the dropdown
            cbCountries.ValueMember = "CountryID";   // The underlying column name for the ID
        }

        private void setupConmponents()
        {
            dateTimePicker.MaxDate = DateTime.Today.AddYears(-18);
            rbMale.Select();
            PersonImage.Image = Resources.Male;
            lbTitle.Text = (_Mode == enMode.eAddNew) ? "Add New Person" : "Update Person Info";
            loadCountries();
            // Find the index of the item that matches "Jordan"
            int index = cbCountries.FindStringExact("Jordan");

            // If found, set it as the selected index
            if (index != -1)
            {
                cbCountries.SelectedIndex = index;
            }
        }

        void loadPersonData()
        {
            if(PersonToEdit == null)
            {
                MessageBox.Show("This form was opent with no selected person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbID.Text = PersonToEdit.ID.ToString();
            txtNationalNo.Text = PersonToEdit.NationalNo;
            txtFirstName.Text = PersonToEdit.FirstName;
            txtSeconedName.Text = PersonToEdit.SecondName;
            txtThirdName.Text = PersonToEdit.ThirdName;
            txtLastName.Text = PersonToEdit.LastName;

            if (PersonToEdit.Gendor == Person.enGendor.Male)
                rbMale.Select();
            else
                rbFemale.Select();

            txtEmail.Text = PersonToEdit.Email;
            txtAddress.Text = PersonToEdit.Address;
            dateTimePicker.Value = PersonToEdit.DateOfBirth;
            txtPhone.Text = PersonToEdit.Phone;
            cbCountries.SelectedValue = PersonToEdit.NationalityCountryID;

            if(!String.IsNullOrEmpty(PersonToEdit.ImagePath))
            {
                PersonImage.Image = Image.FromFile(_ImagePath);
            }

        }

        private void AddEditPersonForm_Load(object sender, EventArgs e)
        {
            setupConmponents();

            if (_Mode == enMode.eEdit)
            {
                loadPersonData();
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_ImagePath))
                return;

            PersonImage.Image = Resources.Male;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_ImagePath))
                return;

            PersonImage.Image = Resources.Female;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _AddNew()
        {
            Person person = new Person(txtNationalNo.Text, txtFirstName.Text, txtSeconedName.Text,
                txtThirdName.Text, txtLastName.Text, dateTimePicker.Value,
                (rbMale.Checked) ? Person.enGendor.Male : Person.enGendor.Female, txtAddress.Text, txtPhone.Text,
                 txtEmail.Text, Convert.ToInt32(cbCountries.SelectedValue), _ImagePath);

            try
            {
                if (PersonService.AddNewPerson(person) != -1)
                {
                    MessageBox.Show("Added new person successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    var result = MessageBox.Show("Can't add new person!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        _AddNew();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void _Update()
        {
               PersonToEdit.NationalNo = txtNationalNo.Text;
               PersonToEdit.FirstName = txtFirstName.Text;
               PersonToEdit.SecondName = txtSeconedName.Text;
               PersonToEdit.ThirdName = txtThirdName.Text;
               PersonToEdit.LastName = txtLastName.Text;


            if (rbMale.Checked)
                PersonToEdit.Gendor = Person.enGendor.Male;
            else
                PersonToEdit.Gendor = Person.enGendor.Female;

            PersonToEdit.Email = txtEmail.Text;
            PersonToEdit.Address = txtAddress.Text;
            PersonToEdit.DateOfBirth = dateTimePicker.Value;
            PersonToEdit.Phone = txtPhone.Text;
            PersonToEdit.NationalityCountryID = Convert.ToInt32(cbCountries.SelectedValue);

            try
            {
                if (PersonService.UpdatePerson(PersonToEdit))
                {
                    MessageBox.Show("Updated person info successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    var result = MessageBox.Show("Can't update person info!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        _Update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNationalNo.Text) || String.IsNullOrEmpty(txtFirstName.Text)
                || String.IsNullOrEmpty(txtSeconedName.Text) || String.IsNullOrEmpty(txtLastName.Text)
                || String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Please fill all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.eAddNew)
                _AddNew();
            else
                _Update();
        }
    }
}
