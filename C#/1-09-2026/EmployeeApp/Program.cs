// See https://aka.ms/new-console-template for more information

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Rahul",101,50000,EmployeeType.Manager);
            emp.DisplayDetails();

            double annualSalary = emp.CalculateAnnualSalary();

            Console.WriteLine($"Annual Salary : {annualSalary}");
        }
    }
}