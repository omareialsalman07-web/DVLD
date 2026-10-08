using DVLD_Business;
using DVLD_Presentation.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.UserControls
{
    public partial class ctrlUserSelecter : UserControl
    {
        private int _PersonID = -1;
        public ctrlUserSelecter()
        {
            InitializeComponent();
        }
        private void ctrlUserSelecter_Load(object sender, EventArgs e)
        {
            comboBox.SelectedIndex = 0;
        }

        private void bnt_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return;

            Person person = (comboBox.SelectedIndex == 0) ? PersonService.Find(Convert.ToInt32(textBox.Text))
                : PersonService.Find(textBox.Text);

            if (person == null)
                return;

            ctrlPersonCard1.LoadPerson(person);
            _PersonID = person.ID;
        }

        public int GetSelected_PersonID() { return _PersonID; }
        public void SetSelected_PersonID(int new_PersonID)
        {
            if(ctrlPersonCard1.LoadPerson(new_PersonID))
                _PersonID = new_PersonID;
        }
        public bool IsPersonSelected() { return _PersonID != -1; }

        private void _OnCreatePersonFinshed(int PersonID)
        {
            ctrlPersonCard1.LoadPerson(PersonID);
            _PersonID = PersonID;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                //textBox.Focus();
                errorProvider1.SetError(textBox, "This text box can't be blank!");
                return;
            }

            bool exists;
            if (comboBox.SelectedIndex == 0)
            {
                exists = PersonService.isExist(Convert.ToInt32(textBox.Text));
            }
            else
            {
                exists = PersonService.isExist(textBox.Text);
            }

            if (!exists)
            {
                //textBox.Focus();
                errorProvider1.SetError(textBox, "No matching person was found.");
            }
            else
            {
                errorProvider1.SetError(textBox, "");
            }
        }

        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonForm addNewPersonForm = new AddEditPersonForm(AddEditPersonForm.enMode.eAddNew);
            addNewPersonForm.onCreatePersonFinish += _OnCreatePersonFinshed;
            addNewPersonForm.ShowDialog();
        }
    }
}
