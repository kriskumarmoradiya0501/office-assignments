namespace Program1;

public static class EmployeeExtensions
{
    public static double CalculateAnnualSalary(this Employee emp)
    {
        return emp.Salary * 12;
    }
}