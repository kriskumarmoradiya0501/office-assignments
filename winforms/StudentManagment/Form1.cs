namespace StudentManagment;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void BtnRegister_Click(object sender, System.EventArgs e)
    {
        string name = txtName.Text;
        int age;

        if (name == "")
        {
            MessageBox.Show("Please enter your name.");
            return;
        }

        if (int.TryParse(txtAge.Text, out age))
        {
        }
        else
        {
            MessageBox.Show("please enter valid number.");
            return;
        }

        string gender = "";
        if (rbMale.Checked)
        {
            gender = "Male";
        }
        if (rbFemale.Checked)
        {
            gender = "Female";
        }
        if (gender == "")
        {
            MessageBox.Show("Please select your gender");
            return;
        }

        if (cmbCourse.SelectedItem == null)
        {
            MessageBox.Show("Please select your course.");
            return;
        }
        string course = cmbCourse.SelectedItem.ToString();

        string dob = dateTimePicker1.Value.ToShortDateString();
        MessageBox.Show("Name : " + name + " Age : " + age + " Course : " + course + " Gender : " + gender + " DOB : " + dob);

        MessageBox.Show("Registration Successful!");
    }

    private void TxtAge_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }



    private void btnForm2_Click(object sender, EventArgs e)
    {
         Form2 f2 = new Form2();
            f2.Show();   // opens Form2 without closing Form1   // TODO: handle the Click event
    }
}
