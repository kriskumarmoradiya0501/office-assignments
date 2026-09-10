namespace PracticeAssignment;

public class LinqBasic
{
    public static void LinqBasicMain()
    {
        string[] names = {"Krish" ,"Jay","Maulik","Preet"};

        var query = from name in names where name.Contains("a") select name;

        foreach(var name in query)
        {
            Console.WriteLine(name);
        }
    }
}
