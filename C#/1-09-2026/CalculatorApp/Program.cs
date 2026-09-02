// See https://aka.ms/new-console-template for more information
namespace Program1;

class Program
{
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