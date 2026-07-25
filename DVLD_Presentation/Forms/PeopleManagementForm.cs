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

        private void LoadPeople()
        {
            try
            {
                List<Person> people = PersonService.GetAllPeople();
                
                foreach(Person person in people)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PeopleManagementForm_Load(object sender, EventArgs e)
        {
            LoadPeople();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmPersonDetails_Click(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItems.Count == 0)
                return;

            int personID = int.Parse(lstPeople.SelectedItems[0].Text);
            Form personCardForm = new PersonCardForm(personID);
            personCardForm.ShowDialog();
        }
    }
}
