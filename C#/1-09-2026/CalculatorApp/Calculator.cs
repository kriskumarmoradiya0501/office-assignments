namespace Program1;

public delegate int ArithmeticOperation(int a,int b);

public class Calculator
{
    public static int Add(int a,int b)
    {
        return a+b;
    }
    public static int Subtract(int a,int b)
    {
        return a-b;
    }

    public static int Multiply(int a,int b)
    {
        return a*b;
    }
    public static int Divide(int a,int b)
    {
        if(b == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
            return 0;
        }

        return a/b;
    }

        static void Main(string[] args)
    {
        ArithmeticOperation op;

        op = Calculator.Add;
        Console.WriteLine("Addition : "+op(10,5));

        op = Calculator.Subtract;
        Console.WriteLine("Subtraction : "+op(10,5));
        op = Calculator.Multiply;
        Console.WriteLine("Multiplication : "+op(10,5));
        op = Calculator.Divide;
        Console.WriteLine("Division : "+op(10,5));

    }
}
