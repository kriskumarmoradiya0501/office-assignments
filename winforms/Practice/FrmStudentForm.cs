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
            if (chkCsharp.Checked) skills += "C# ";
            if (chkJava.Checked) skills += "Java ";
            if (chkPython.Checked) skills += "Python ";
            if (chkSql.Checked) skills += "SQL ";

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
        private int SelectedRowIndex = -1;
        private void DgvStudents_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Grid view is empty.");
                return;
            }

            SelectedRowIndex = e.RowIndex;

            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

            txtName.Text = row.Cells["Name"].Value?.ToString();
            txtAge.Text = row.Cells["Age"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();

            string gender = row.Cells["Gender"].Value?.ToString();

            rbMale.Checked = gender == "Male";
            rbFemale.Checked = gender == "Female";
            rbOther.Checked = gender == "Other";

            string department = row.Cells["Department"].Value?.ToString();

            MessageBox.Show(row.Cells["Skills"].Value?.ToString());

            string skillsSpliter = row.Cells["Skills"].Value?.ToString() ?? "";


            chkCsharp.Checked = skillsSpliter.Contains("C# ");
            chkJava.Checked = skillsSpliter.Contains("Java ");
            chkPython.Checked = skillsSpliter.Contains("Python ");
            chkSql.Checked = skillsSpliter.Contains("SQL ");


            cmbDepartment.SelectedItem = department;

        }

        private void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            if (SelectedRowIndex == -1)
            {
                MessageBox.Show("Please select a student first.");
                return;
            }

            DataGridViewRow row = dgvStudents.Rows[SelectedRowIndex];

            row.Cells["Name"].Value = txtName.Text;

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Please enter valid age.");
                txtAge.Focus();
                return;
            }
            row.Cells["Age"].Value = age;

            row.Cells["Address"].Value = txtAddress.Text;

            row.Cells["gender"].Value = "";
            if (rbFemale.Checked) row.Cells["Gender"].Value = "Female";
            if (rbMale.Checked) row.Cells["Gender"].Value = "Male";
            if (rbOther.Checked) row.Cells["Gender"].Value = "Other";
            if (row.Cells["gender"].Value == "")
            {
                MessageBox.Show("Please select your gender");
                return;
            }

            row.Cells["Skills"].Value = "";
            if (chkCsharp.Checked) row.Cells["Skills"].Value += "C# ";
            if (chkJava.Checked) row.Cells["Skills"].Value += "Java ";
            if (chkPython.Checked) row.Cells["Skills"].Value += "Python ";
            if (chkSql.Checked) row.Cells["Skills"].Value += "SQL ";

            if (row.Cells["Skills"].Value == "")
            {
                MessageBox.Show("Please select skills");
                return;
            }

            row.Cells["DOB"].Value = dtpDob.Value.ToShortDateString();

            row.Cells["Department"].Value = cmbDepartment.Text;


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedRowIndex == -1)
            {
                MessageBox.Show("Please select a student first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                dgvStudents.Rows.RemoveAt(SelectedRowIndex);

                SelectedRowIndex = -1;

                clear();

                MessageBox.Show("Student deleted successfully.");
            }
        }

    }
}