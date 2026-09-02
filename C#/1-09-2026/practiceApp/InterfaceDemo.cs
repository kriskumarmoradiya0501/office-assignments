namespace Program1;

interface IEmployee
{
    void DisplayDetails();
    void CalculateBonus();
}

class Employee
{
    public string name {get; set;}
    public int EmployeeID {get; set;}
    public double Salary {get; set;}

    public Employee(string name,int EmployeeID,double Salary)
    {
        this.name = name;
        this.EmployeeID = EmployeeID;
        this.Salary = Salary;
    }

    public virtual void CalculateBonus()
    {
        Console.WriteLine("Calculation Of Bonus");
    }

}

class Manager : Employee, IEmployee
{
    public Manager(string name, int EmployeeID, double Salary) : base(name, EmployeeID, Salary)
    {
        
    }

    public override void CalculateBonus()
    {
        double bonus = Salary * 0.20;

        Console.WriteLine($"Manager Bonus : {bonus}");
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Details of Manager \nName : {name}\nEmployeeId : {EmployeeID}\nSalary : {Salary}");
    }
}

class Developer : Employee, IEmployee
{
    public Developer(string name, int EmployeeID, double Salary) : base(name, EmployeeID, Salary)
    {
        
    }

    public override void CalculateBonus()
    {
        double bonus = Salary * 0.10;

        Console.WriteLine($"Developer Bonus : {bonus}");
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Details of Developer \nName : {name}\nEmployeeId : {EmployeeID}\nSalary : {Salary}");
    }
}

class InterfaceDemo
{
    public static void InterfaceDemoMain()
    {
        IEmployee manager =
            new Manager("John deo", 101, 8000);

        IEmployee developer =
            new Developer("Alice Smith", 102, 6000);


        Console.WriteLine("===== MANAGER =====");

        manager.DisplayDetails();
        manager.CalculateBonus();


        Console.WriteLine();


        Console.WriteLine("===== DEVELOPER =====");

        developer.DisplayDetails();
        developer.CalculateBonus();
    }
}
