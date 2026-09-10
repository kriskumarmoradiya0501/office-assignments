namespace AssignmentProject;

public partial class CalculatorForm : Form
{
    public CalculatorForm()
    {
        InitializeComponent();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);
            double result = num1 + num2;
            lblResult.Text = $"Result: {result}";
        }
        catch (Exception)
        {
            MessageBox.Show("Please enter valid numbers");
        }
    }
}
