namespace GeneralPractice;


public class AttendencejaggedArray
{
    public static void Attendance()
    {
        // 1. Accept number of days
        Console.Write("Enter number of days: ");
        int days = int.Parse(Console.ReadLine());

        // Create jagged array
        int[][] attendance = new int[days][];

        // 2. For each day
        for (int i = 0; i < days; i++)
        {
            Console.Write($"Enter number of absent students for Day {i + 1}: ");
            int absent = int.Parse(Console.ReadLine());

            // Create array for that day's absent students
            attendance[i] = new int[absent];

            // 3. Accept roll numbers
            for (int j = 0; j < absent; j++)
            {
                Console.Write($"Enter absent roll number: ");
                attendance[i][j] = int.Parse(Console.ReadLine());
            }
        }

        // 5. Display attendance
        Console.WriteLine("\nAbsent Students:");

        for (int i = 0; i < days; i++)
        {
            Console.Write($"Day {i + 1}: ");

            for (int j = 0; j < attendance[i].Length; j++)
            {
                Console.Write(attendance[i][j] + " ");
            }

            Console.WriteLine();
        }
    }
}