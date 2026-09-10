using System;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, System.EventArgs e)
        {
// Text Box
            string name = txtName.Text;
            if (name == "")
            {
                MessageBox.Show("Please enter a name.");
                return;
            }
// Text Box only digit
            int age;
            if (int.TryParse(txtAge.Text, out age))
            {

            }
            else
            {
                MessageBox.Show("Please enter valid number.");
                return;
            }
            if (age <= 0 || age > 100)
            {
                MessageBox.Show("Please enter a valid age between 1 and 100.");
                return;
            }

// Combo box
            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please select your gender.");
                return;
            }
            string gender = cmbGender.SelectedItem.ToString();

// check box
            string skills = "";

            if (chkCSharp.Checked)
            {
                skills += " C#";
            }
            if (chkJava.Checked)
            {
                skills += " JAVA";
            }
            if (chkPython.Checked)
            {
                skills += " Python";
            }
            if (chkSql.Checked)
            {
                skills += " SQL";
            }
            if (string.IsNullOrWhiteSpace(skills))
            {
                MessageBox.Show("Please select any skills");
                return;
            }
// numberUpDown 
            int days = (int)nudDays.Value;
// Date time
            DateTime dob = dtpDOB.Value;
// comboBox
            if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select department");
                return;
            }

            string department = cmbDepartment.SelectedItem.ToString();
            int departmentIndex = cmbDepartment.SelectedIndex;

// ListBox
            if (lstSkill.SelectedIndex == -1)
            {
                MessageBox.Show("Please select any skill");
                return;
            }

            string skill = lstSkill.SelectedItem.ToString();
            int skillIndex = lstSkill.SelectedIndex;
// List Multiple Value selection
            if (lstSkills.SelectedIndex == -1)
            {
                MessageBox.Show("Please select any of skills");
                return;
            }

            string skillss = "";
            foreach (var item in lstSkills.SelectedItems)
            {
                skillss += item.ToString() + " ";
            }
// Radio button with group Box
            string size = "";

            if (rbS.Checked) size = "S";
            else if (rbM.Checked) size = "M";
            else if (rbL.Checked) size = "L";
            else if (rbXL.Checked) size = "XL";

            if (string.IsNullOrEmpty(size))
            {
                MessageBox.Show("Please select any one size");
            }


            MessageBox.Show("Name : " + name + " Age : " + age + " Gender : " + gender + " Skills : " + skills + " Days : " + days + " DOB : " + dob.ToShortDateString() + "Department Name : " + department + " Department Index : " + departmentIndex + "Skill : " + skill + " Skill index : " + skillIndex + " Skills name : " + skillss + " Size = " + size);

            Clean();

        }

// KeyPress Event
        private void TxtAge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

// On click event
        private void BtnShowDept_Click(object sender, System.EventArgs e)
        {
            if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select department");
                return;
            }
            string department = cmbDepartment.SelectedItem.ToString();
            int departmentIndex = cmbDepartment.SelectedIndex;
            MessageBox.Show("Department Name : " + department + " Department Index : " + departmentIndex);

        }

// On click event
        private void BtnShowSkill_Click(object sender, System.EventArgs e)
        {
            if (lstSkill.SelectedIndex == -1)
            {
                MessageBox.Show("Please select any skill");
                return;
            }

            string skill = lstSkill.SelectedItem.ToString();
            int skillIndex = lstSkill.SelectedIndex;
            MessageBox.Show("Skill : " + skill + " Skill index : " + skillIndex);
        }

// On Click Event
        private void BtnShoeSkills_Click(object sender, System.EventArgs e)
        {
            if (lstSkills.SelectedIndex == -1)
            {
                MessageBox.Show("Please select any of skills");
                return;
            }

            string skills = "";
            foreach (var item in lstSkills.SelectedItems)
            {
                skills += item.ToString() + " ";
            }
            MessageBox.Show("Skills name : " + skills);

        }

// On click event
        private void BtnShowTshirtSize_Click(object sender, EventArgs e)
        {
            string size = "";

            if (rbS.Checked) size = "S";
            else if (rbM.Checked) size = "M";
            else if (rbL.Checked) size = "L";
            else if (rbXL.Checked) size = "XL";

            if (string.IsNullOrEmpty(size))
            {
                MessageBox.Show("Please select any one size");
            }
            else
            {
                MessageBox.Show("Size = " + size);
            }
        }


//On click event
        private void BtnClear_Click(object sender, System.EventArgs e)
        {
            Clean();
        }

// Clean Method
        public void Clean()
        {
                        txtName.Clear();
            nudDays.Value = 1;
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;

            chkCSharp.Checked = false;
            chkJava.Checked = false;
            chkPython.Checked = false;
            chkSql.Checked = false;

            lstSkills.ClearSelected();
            lstSkill.ClearSelected();

            // dtpDOB.Value = DateTime.Today;

            rbS.Checked = false;
            rbM.Checked = false;
            rbL.Checked = false;
            rbXL.Checked = false;

            cmbDepartment.SelectedIndex = -1;

            txtName.Focus();
        }

// Text chenged event 
        private void TxtLiveText_TextChanged(object sender, System.EventArgs e)
        {
            lblLiveText.Text = txtLiveText.Text;
        }

// Key Press event
        private void TxtKeyPress_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            lblKeyPress.Text = ""+ e.KeyChar;
        }

        private void TxtKeyDown_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            lblKeyDown.Text = e.KeyCode.ToString();
        }

        private void TxtKeyUpEvent_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Enter Pressed");
            }
        }

        private void TxtName_Enter(object sender, System.EventArgs e)
        {
            txtName.BackColor = Color.LightBlue;
        }

        private void TxtName_Leave(object sender, System.EventArgs e)
        {
            txtName.BackColor = SystemColors.Window;
        }

        private void BtnMouse_MouseEnter(object sender, System.EventArgs e)
        {
            btnMouse.Text = "Mouse Entered..";
        }

        private void BtnMouse_MouseLeave(object sender, System.EventArgs e)
        {
            btnMouse.Text = "Mouse Lefted..";
        }



    }
}