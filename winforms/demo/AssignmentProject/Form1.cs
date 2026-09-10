using System;
using System.Windows.Forms;

namespace AssignmentProject;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnCalculator_Click(object sender, EventArgs e)
    {
        CalculatorForm calcForm = new CalculatorForm();
        calcForm.Show();
    }

    private void btnStudentRegistration_Click(object sender, EventArgs e)
    {
        StudentRegistrationForm studentForm = new StudentRegistrationForm();
        studentForm.Show();
    }

    private void btnControlDemo_Click(object sender, EventArgs e)
    {
        FrmControl frmControl = new FrmControl();
        frmControl.Show();
    }

    private void btnDialogDemo_Click(object sender, EventArgs e)
    {
        FrmDialog frmDialog = new FrmDialog();
        frmDialog.Show();
    }

    private void btnMdiDemo_Click(object sender, EventArgs e)
    {
        FrmMain frmMain = new FrmMain();
        frmMain.Show();
    }

    private void btnEmployee_Click(object sender, EventArgs e)
    {
        FrmEmployee frmEmp = new FrmEmployee();
        frmEmp.Show();
    }

    private void btnApiDemo_Click(object sender, EventArgs e)
    {
        ApiForm apiForm = new ApiForm();
        apiForm.Show();
    }

    private void btnEvents_Click(object sender, EventArgs e)
    {
        FrmEvents frmEvents = new FrmEvents();
        frmEvents.Show();
    }

    private void btnAbout_Click(object sender, EventArgs e)
    {
        AboutForm aboutForm = new AboutForm();
        aboutForm.Show();
    }
}
