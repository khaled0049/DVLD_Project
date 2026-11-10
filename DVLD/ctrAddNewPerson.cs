using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace DVLD
{
    public partial class ctrAddNewPerson : UserControl
    {
        private DataTable dt = null;

        public enum enMode { AddNew = 0, Update = 1 }; 
        enMode Mode {get;  set; }

        public ctrAddNewPerson()
        {
            InitializeComponent();
            dt = clsPerson.GetAllNationalNo();
            Mode = enMode.AddNew;
        }



        private void txtNationalNO_TextChanged(object sender, EventArgs e)
        {
            // search for the NationalNo in the DataTable if exist then show error provider
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] foundRows = dt.Select("NationalNo = '" + txtNationalNO.Text + "'");
                if (foundRows.Length > 0)
                {
                    errorProvider1.SetError(txtNationalNO, "This National No already exists.");
                }
                else
                {
                    errorProvider1.SetError(txtNationalNO, "");
                }
            }
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                rbFemale.Checked = false;
            }
            pbImage.Image = Properties.Resources.Male_512;

        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                rbMale.Checked = false;
            }
            pbImage.Image = Properties.Resources.Female_512;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                errorProvider1.SetError(txtEmail, "Invalid email address.");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void ctrAddNewPerson_Load(object sender, EventArgs e)
        {
            DataTable dtCountry = clsCountry.GetAllCountries();

            cbCountry.DataSource = null;

            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";

            cbCountry.DataSource = dtCountry;

            cbCountry.SelectedIndex =
                cbCountry.FindStringExact("Jordan");

        }

        private void lbsetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // open file dialog to select image write code 

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbImage.ImageLocation = fileDialog.FileName;
                }
            }

        }

        private bool CheckInputFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSecondName.Text) ||
                string.IsNullOrWhiteSpace(txtThirdName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNationalNO.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                cbCountry.SelectedIndex == -1 ||
                (!rbMale.Checked && !rbFemale.Checked)
                )
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInputFields())
            {
                return;
            }
            DataTable dtCountry = (DataTable)cbCountry.DataSource;

            MessageBox.Show(
                "ValueMember: " + cbCountry.ValueMember +
                "\nCountryID Exists: " + dtCountry.Columns.Contains("CountryID") +
                "\nSelectedValue Type: " + cbCountry.SelectedValue.GetType().Name);


            clsPerson person = new clsPerson();
            person.FirstName = txtName.Text;
            person.SecondName = txtSecondName.Text;
            person.ThirdName = txtThirdName.Text;
            person.LastName = txtLastName.Text;
            person.Email = txtEmail.Text;
            person.NationalNo = txtNationalNO.Text;
            person.Phone = txtPhone.Text;
            person.Address = txtAddress.Text;
            person.NationalityCountryID = Convert.ToInt32(cbCountry.SelectedValue);
            person.ImagePath = pbImage.ImageLocation;
            if (rbMale.Checked)
            {
                person.Gendor = 0;
            }
            else if (rbFemale.Checked)
            {
                person.Gendor = 1;
            }
            person.DateOfBirth = dtpDateOfBirth.Value.Date;

            person.Save();


        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
