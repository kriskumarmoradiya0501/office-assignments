using System;
using System.Windows.Forms;

namespace Practice
{
    public partial class FrmStudentForm : Form
    {
        public FrmStudentForm()
        {
            InitializeComponent();
            dgvStudents.Columns.Add("Name", "name");
            dgvStudents.Columns.Add("Age", "age");
            dgvStudents.Columns.Add("DOB", "dob");
            dgvStudents.Columns.Add("Gender", "gender");
            dgvStudents.Columns.Add("Department", "department");
            dgvStudents.Columns.Add("Skills", "skills");
            dgvStudents.Columns.Add("Address", "address");

        }

        private void BtnClear_Click(object sender, System.EventArgs e)
        {
            clear();
        }

        private void BtnSubmit_Click(object sender, System.EventArgs e)
        {
            string name = txtName.Text;
            if (name == "")
            {
                MessageBox.Show("Please enter the name.");
                txtName.Focus();
                return;
            }
            int age;
            if (!int.TryParse(txtAge.Text, out age))
            {
                MessageBox.Show("Please enter valid age.");
                txtAge.Focus();
                return;
            }

            string dob = dtpDob.Value.ToShortDateString();

            string gender = "";
            if (rbMale.Checked) gender = "Male";
            if (rbFemale.Checked) gender = "Female";
            if (rbOther.Checked) gender = "Other";
            if (gender == "")
            {
                MessageBox.Show("Please select your gender.");
                return;
            }

            if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your Department.");
                cmbDepartment.Focus();
                return;
            }
            string department = cmbDepartment.SelectedItem.ToString();

            string skills = "";
            if (chkCsharp.Checked) skills += "C#";
            if (chkJava.Checked) skills += " Java";
            if (chkPython.Checked) skills += " Python";
            if (chkSql.Checked) skills += " SQL";

            if (skills == "")
            {
                MessageBox.Show("Please select skills");
                return;
            }

            string address = txtAddress.Text;
            if (address == "")
            {
                MessageBox.Show("Please enter your address.");
                txtAddress.Focus();
                return;
            }


            MessageBox.Show("Name : " + name + " Age : " + age + " DOB : " + dob + " Skills : " + skills + " Department : " + department + " Address : " + address);

            dgvStudents.Rows.Add(name, age, dob, gender, department, skills, address);
            clear();

        }

        public void clear()
        {
            txtName.Clear();
            txtAge.Clear();
            txtAddress.Clear();

            cmbDepartment.SelectedIndex = -1;

            chkCsharp.Checked = false;
            chkJava.Checked = false;
            chkPython.Checked = false;
            chkSql.Checked = false;

            rbFemale.Checked = false;
            rbMale.Checked = false;
            rbOther.Checked = false;

        }

        private void TxtAge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtSearch_TextChanged(object sender, System.EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string name = row.Cells["Name"].Value?.ToString().ToLower();

                if (name != null && name.Contains(search))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}