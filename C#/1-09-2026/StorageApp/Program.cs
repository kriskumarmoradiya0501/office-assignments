// See https://aka.ms/new-console-template for more information
namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Integer Storage
            Storage<int> productIds = new Storage<int>();

            productIds.AddItem(101);
            productIds.AddItem(102);
            productIds.AddItem(103);

            Console.WriteLine("===== PRODUCT IDs =====");

            productIds.DisplayItems();

            productIds.RemoveItem(102);

            Console.WriteLine("\nAfter removing 102:");

            productIds.DisplayItems();

            Console.WriteLine("\nItem at index 0: " + productIds[0]);


            // String Storage
            Storage<string> employeeNames = new Storage<string>();

            employeeNames.AddItem("Rahul");
            employeeNames.AddItem("Amit");
            employeeNames.AddItem("Krish");

            Console.WriteLine("\n===== EMPLOYEE NAMES =====");

            employeeNames.DisplayItems();

            employeeNames.RemoveItem("Amit");

            Console.WriteLine("\nAfter removing Amit:");

            employeeNames.DisplayItems();

            Console.WriteLine("\nItem at index 0: " + employeeNames[0]);


            // Double Storage
            Storage<double> productPrices = new Storage<double>();

            productPrices.AddItem(500.50);
            productPrices.AddItem(1000.75);
            productPrices.AddItem(250.25);

            Console.WriteLine("\n===== PRODUCT PRICES =====");

            productPrices.DisplayItems();

            productPrices.RemoveItem(1000.75);

            Console.WriteLine("\nAfter removing 1000.75:");

            productPrices.DisplayItems();

            Console.WriteLine("\nItem at index 0: " + productPrices[0]);
        }
    }
}