namespace AssignmentProject;

public partial class StudentRegistrationForm : Form
{
    public StudentRegistrationForm()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string course = txtCourse.Text;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(course))
        {
            MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show($"Student {name} registered successfully for {course}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtName.Clear();
            txtCourse.Clear();
        }
    }
}
