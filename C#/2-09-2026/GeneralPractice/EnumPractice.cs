namespace GeneralPractice;

public class EnumPractice
{
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public static void EnumMain()
    {
        Console.WriteLine(WeekDays.Friday);

        int day = (int)WeekDays.Friday;
        Console.WriteLine(day);

        WeekDays wd = (WeekDays)5;
        Console.WriteLine(wd);
    }
}
