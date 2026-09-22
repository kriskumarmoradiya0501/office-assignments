namespace MvcXunitDemo.Services;

public class DemoService
{
    public string GetMessage()
    {
        Console.WriteLine(">>> SERVICE START");

        string message = "Hello from DemoService";

        Console.WriteLine("<<< SERVICE END");

        return message;
    }
}