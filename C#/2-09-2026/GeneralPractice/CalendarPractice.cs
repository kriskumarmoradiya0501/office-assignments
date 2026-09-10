namespace GeneralPractice;

public class CalendarPractice
{
    public static void CalendarMain()
    {
        Console.Write("Enter month (1-12): ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine($"Calendar for {month}/{year}");

        DateTime firstDay = new DateTime(year, month, 1);

        DayOfWeek day = firstDay.DayOfWeek;

        int startDay = (int)day;

        Console.WriteLine($"First day is: {day}");
        Console.WriteLine($"Number: {startDay}");

        int totalDays = DateTime.DaysInMonth(year, month);

        Console.WriteLine($"Total days: {totalDays}");

        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        int currentDay = 1;

        for (int week = 0; week < 6; week++)
        {
            for (int dayPosition = 0; dayPosition < 7; dayPosition++)
            {
                if (currentDay > totalDays)
                {
                    break;
                }

                if (week == 0 && dayPosition < startDay)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write($"{currentDay,2}  ");
                    currentDay++;
                }
            }

            Console.WriteLine();

            if (currentDay > totalDays)
            {
                break;
            }
        }
    }
}