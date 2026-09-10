namespace Practice;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void BtnForm2_Click(object sender, System.EventArgs e)
    {
        Form2 f2 = new Form2();
        f2.Show();
    }

    // private void BtnForm3_Click(object sender, System.EventArgs e)
    // {
    //     Form3 f3 = new Form3();
    //     f3.Show();
    // }

        private void BtnForm3_Click(object sender, System.EventArgs e)
    {
        Form3 f3 = new Form3();
        f3.ShowDialog();
    }

    private void LblDataSharingForm_Click(object sender, System.EventArgs e)
    {
        FrmPassingDataOneToOther1 f4 = new FrmPassingDataOneToOther1();
        f4.Show();
    }

    private void BtnStudetFrm_Click(object sender, System.EventArgs e)
    {
        FrmStudentForm f5 = new FrmStudentForm();
        f5.Show();
    }
}
