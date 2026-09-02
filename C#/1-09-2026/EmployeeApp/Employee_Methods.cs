namespace Program1;

public partial class Employee
{
    public void DisplayDetails()
    {
        Console.WriteLine($"Name : {Name}\nID : {ID}\nSalary : {Salary}\nType : {Type}");
    }
}