using System;

namespace PracticeAssignment
{
    public class ExceptionHandaling
    {
        public static void ExceptionHandalingMain(string[] args)
        {
            try
            {
                Console.Write("Enter first number: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int y = int.Parse(Console.ReadLine());

                int result = x / y;

                Console.WriteLine("Result = " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter numbers only.");
            }
            finally
            {
                Console.WriteLine("Program execution completed.");
            }
        }
        public static void ThrowPractice()
        {
            try
            {
                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());

                if (age < 18)
                {
                    throw new Exception("Age must be 18 or above.");
                }

                Console.WriteLine("You are eligible.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Program End");
        }
    }
}
