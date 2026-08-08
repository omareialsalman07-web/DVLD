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

namespace DVLD_Presentation.Forms
{
    public partial class PeopleManagementForm : Form
    {
        public PeopleManagementForm()
        {
            InitializeComponent();
        }
        void FillPeopleList(List<Person> people)
        {
            lstPeople.Items.Clear();

            foreach (Person person in people)
            {
                ListViewItem item = new ListViewItem(person.ID.ToString());
                item.SubItems.Add(person.NationalNo);
                item.SubItems.Add(person.FirstName);
                item.SubItems.Add(person.SecondName);
                item.SubItems.Add(person.ThirdName);
                item.SubItems.Add(person.LastName);
                item.SubItems.Add(person.Gendor.ToString());
                item.SubItems.Add(person.DateOfBirth.ToString());
                item.SubItems.Add(person.NationalityCountryID.ToString());
                item.SubItems.Add(person.Phone);
                item.SubItems.Add(person.Email);

                lstPeople.Items.Add(item);
            }

            lbRecoreds.Text = people.Count.ToString();
        }
        private void LoadPeople()
        {
            try
            {
                List<Person> people = PersonService.GetAllPeople();
                FillPeopleList(people);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPeople(PersonService.enFilter fillterBy, string value)
        {
            try
            {
                List<Person> people = PersonService.GetAllPeople(fillterBy, value);
                FillPeopleList(people);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void loadCountries_ToFilterCombo()
        {
            try
            {
                DataTable dtCountries = CountryService.GetAllCountries_ToTable();

                cbNationality.DataSource = dtCountries;
                cbNationality.DisplayMember = "CountryName"; // The column name you want to show in the dropdown
                cbNationality.ValueMember = "CountryID";   // The underlying column name for the ID
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PeopleManagementForm_Load(object sender, EventArgs e)
        {
            LoadPeople();
            rbMale.Select();
            cbFilter.SelectedIndex = 0; // None
            loadCountries_ToFilterCombo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmPersonDetails_Click(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no seleced item to this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int personID = int.Parse(lstPeople.SelectedItems[0].Text);
            Form personCardForm = new PersonCardForm(personID);
            personCardForm.ShowDialog();
        }
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no seleced item to this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int personID = int.Parse(lstPeople.SelectedItems[0].Text);

            try
            {
                var result = MessageBox.Show("Are you sure of deleting this person", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    PersonService.DeletePerson(personID);
                    LoadPeople();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form form = new AddEditPersonForm(AddEditPersonForm.enMode.eAddNew);
            form.ShowDialog();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPeople();
            cbFilter.SelectedIndex = 0; // None

        }
        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            Form form = new AddEditPersonForm(AddEditPersonForm.enMode.eAddNew);
            form.ShowDialog();
        }
        private void tsmEdit_Click(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no seleced item to this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Person personToEdit = PersonService.Find(int.Parse(lstPeople.SelectedItems[0].Text));
                Form form = new AddEditPersonForm(AddEditPersonForm.enMode.eEdit, personToEdit);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetFilterControls()
        {
            pFilterValue.Visible = true;
            mtxtFilter.Visible = true;
            pGendorFilter.Visible = false;
            cbNationality.Visible = false;
        }

        PersonService.enFilter _Fillter;
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetFilterControls();

            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    pFilterValue.Visible = false;
                    break;
                case 7: // Nationality
                    mtxtFilter.Visible = false;
                    cbNationality.Visible = true;
                    break;
                case 8: // Gendor
                    mtxtFilter.Visible = false;
                    pGendorFilter.Visible = true;
                    break;
            }

            _Fillter = (PersonService.enFilter)cbFilter.SelectedIndex;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value;
            switch(_Fillter)
            {
                case PersonService.enFilter.NationalityCountryID:
                    value = cbNationality.SelectedValue.ToString();
                    break;
                case PersonService.enFilter.Gendor:
                    value = rbMale.Checked? "0" : "1";
                    break;
                default:
                    value = mtxtFilter.Text;
                    break;
            }

            LoadPeople(_Fillter, value);
        }
    }
}
