namespace GeneralPractice;

public class DefaultAndRefPeraDemo
{
    // 1. Function with default parameter
    public static void StudentInfo(string name, string grade = "B")
    {
        Console.WriteLine($"Student Name: {name}");
        Console.WriteLine($"Grade: {grade}");
    }

    // 2. Function with ref parameter
    public static void AddBonus(ref int score, string grade)
    {
        if (grade == "A")
        {
            score = score + 10;
        }
        else if (grade == "B")
        {
            score = score + 5;
        }
        else if (grade == "C")
        {
            score = score;
        }
    }

    public static void DefaultRef()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter grade (A/B/C) or press Enter for default B: ");
        string grade = Console.ReadLine();

        // If user doesn't enter grade, default value "B" is used
        if (grade == "")
        {
            StudentInfo(name);
            grade = "B";
        }
        else
        {
            StudentInfo(name, grade);
        }

        Console.Write("Enter score: ");
        int score = int.Parse(Console.ReadLine());

        Console.WriteLine($"Original Score: {score}");

        AddBonus(ref score, grade);

        Console.WriteLine($"New Score: {score}");
    }
}
