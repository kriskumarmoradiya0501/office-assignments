using System;
using System.Windows.Forms;

namespace AssignmentProject;

public partial class FrmEmployee : Form
{
    private EmployeeService service = new EmployeeService();

    public FrmEmployee()
    {
        InitializeComponent();
        LoadEmployees();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee
            {
                EmpId = int.Parse(txtEmpId.Text),
                EmpName = txtEmpName.Text,
                Salary = decimal.Parse(txtSalary.Text),
                DeptNo = int.Parse(txtDeptNo.Text)
            };
            service.AddEmployee(emp);
            MessageBox.Show("Employee added successfully!");
            LoadEmployees();
            ClearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee
            {
                EmpId = int.Parse(txtEmpId.Text),
                EmpName = txtEmpName.Text,
                Salary = decimal.Parse(txtSalary.Text),
                DeptNo = int.Parse(txtDeptNo.Text)
            };
            bool updated = service.UpdateEmployee(emp);
            if (updated)
            {
                MessageBox.Show("Employee updated successfully!");
                LoadEmployees();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Employee not found.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int empId = int.Parse(txtEmpId.Text);
            bool deleted = service.DeleteEmployee(empId);
            if (deleted)
            {
                MessageBox.Show("Employee deleted successfully!");
                LoadEmployees();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Employee not found.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void btnViewAll_Click(object sender, EventArgs e)
    {
        LoadEmployees();
    }

    private void LoadEmployees()
    {
        dgvEmployees.DataSource = null;
        dgvEmployees.DataSource = service.GetAllEmployees();
    }

    private void ClearFields()
    {
        txtEmpId.Clear();
        txtEmpName.Clear();
        txtSalary.Clear();
        txtDeptNo.Clear();
    }
}
