namespace GeneralPractice;

public class FunctionPractice
{
    // 1. Factorial - Instance Method + Recursion
    public int fact(int n)
    {
        if (n == 0)
            return 1;
        else
            return n * fact(n - 1);
    }


    // 2. Power - Static Method + Recursion
    public static int Power(int x, int y)
    {
        if (y == 0)
            return 1;
        else
            return x * Power(x, y - 1);
    }


    // 3. Method Overloading - 2 integers
    public static int add(int x, int y)
    {
        Console.WriteLine("2 integer parameters");
        return x + y;
    }


    // 4. Method Overloading - 3 integers
    public static int add(int x, int y, int z)
    {
        Console.WriteLine("3 integer parameters");
        return x + y + z;
    }


    // 5. Method Overloading - 2 floats
    public static float add(float x, float y)
    {
        Console.WriteLine("2 float parameters");
        return x + y;
    }


    // 6. Method Overloading - No parameters
    public static int add()
    {
        Console.WriteLine("No parameters");
        return 0;
    }


    // 7. out parameter
    public static void max(int x, int y, out int mx)
    {
        if (x > y)
            mx = x;
        else
            mx = y;
    }


    // 8. ref parameter
    public static void swap(ref int x, ref int y)
    {
        int temp = x;

        x = y;
        y = temp;

        Console.WriteLine($"Inside swap: x = {x}, y = {y}");
    }


    // Main function for testing
    public static void FunMain()
    {
        FunctionPractice ft = new FunctionPractice();

        // Factorial
        Console.WriteLine("Factorial : " + ft.fact(5));

        // Power
        Console.WriteLine("Power : " + FunctionPractice.Power(2, 3));

        // Add
        Console.WriteLine("Add int : " + add(10, 20));

        Console.WriteLine("Add int : " + add(10, 20, 30));

        Console.WriteLine("Add float : " + add(10.5f, 20.5f));

        Console.WriteLine("Add no parameter : " + add());

        // Maximum using out
        int maxValue;

        max(10, 20, out maxValue);

        Console.WriteLine("Max : " + maxValue);

        // Swap using ref
        int a = 10;
        int b = 20;

        Console.WriteLine($"Before swap: a = {a}, b = {b}");

        swap(ref a, ref b);

        Console.WriteLine($"After swap: a = {a}, b = {b}");
    }
}