using System;
using System.Collections.Generic;
using Npgsql;

namespace AssignmentProject;

public class EmployeeService
{
    private string connectionString = "Server=localhost;port=5432;Database=office;User Id=postgres;Password=guest;";

    public void AddEmployee(Employee emp)
    {
        using var conn = new NpgsqlConnection(connectionString);
        try
        {
            conn.Open();
            using var cmd = new NpgsqlCommand("INSERT INTO t_employee(empid, empname, salary, deptno) VALUES (@id, @name, @salary, @deptno)", conn);
            cmd.Parameters.AddWithValue("id", emp.EmpId);
            cmd.Parameters.AddWithValue("name", emp.EmpName);
            cmd.Parameters.AddWithValue("salary", emp.Salary);
            cmd.Parameters.AddWithValue("deptno", emp.DeptNo);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding employee: " + ex.Message);
        }
    }

    public List<Employee> GetAllEmployees()
    {
        var list = new List<Employee>();
        try 
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT empid, empname, salary, deptno FROM t_employee", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Employee
                {
                    EmpId = reader.GetInt32(0),
                    EmpName = reader.GetString(1),
                    Salary = reader.GetDecimal(2),
                    DeptNo = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error retrieving employees: " + ex.Message);
        }
        return list;
    }

    public Employee GetEmployee(int empId)
    {
        try
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT empid, empname, salary, deptno FROM t_employee WHERE empid = @id", conn);
            cmd.Parameters.AddWithValue("id", empId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Employee
                {
                    EmpId = reader.GetInt32(0),
                    EmpName = reader.GetString(1),
                    Salary = reader.GetDecimal(2),
                    DeptNo = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                };
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error retrieving employee: " + ex.Message);
        }
        return null;
    }

    public bool UpdateEmployee(Employee emp)
    {
        try
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("UPDATE t_employee SET empname=@name, salary=@salary, deptno=@deptno WHERE empid=@id", conn);
            cmd.Parameters.AddWithValue("id", emp.EmpId);
            cmd.Parameters.AddWithValue("name", emp.EmpName);
            cmd.Parameters.AddWithValue("salary", emp.Salary);
            cmd.Parameters.AddWithValue("deptno", emp.DeptNo);
            int affected = cmd.ExecuteNonQuery();
            return affected > 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error updating employee: " + ex.Message);
            return false;
        }
    }

    public bool DeleteEmployee(int empId)
    {
        try
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM t_employee WHERE empid = @id", conn);
            cmd.Parameters.AddWithValue("id", empId);
            int affected = cmd.ExecuteNonQuery();
            return affected > 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error deleting employee: " + ex.Message);
            return false;
        }
    }
}
