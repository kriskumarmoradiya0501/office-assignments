namespace GeneralPractice;

public class StudentInfo
{
    // Instance variables
    private string name;
    private int age;
    private char grade;

    // Static member
    public static int totalStudents = 0;

    // Constructor
    public StudentInfo(string name, int age, char grade)
    {
        this.name = name;
        this.age = age;
        this.grade = grade;

        // Increase total students
        totalStudents++;
    }

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public char Grade
    {
        get { return grade; }
        set
        {
            if (value == 'A' || value == 'B' || value == 'C')
            {
                grade = value;
            }
            else
            {
                grade = '\0';
            }
        }
    }

    // Display information
    public void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Grade: {Grade}");
    }
}