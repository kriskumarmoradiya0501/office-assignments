namespace MvcXunitDemo.Middleware;

public class DemoMiddleware
{
    // here RequestDelagete means that what process will be done next with this http request
    private readonly RequestDelegate _next;

    public DemoMiddleware(RequestDelegate next)
    {
        _next = next;
    }
public async Task InvokeAsync(HttpContext context)
{
    Console.WriteLine("========== MIDDLEWARE START ==========");

    // here await is working for continue the request
    // wait for this asynchronous operation to complete     
    await _next(context);

    Console.WriteLine("========== MIDDLEWARE END ==========");
}
}