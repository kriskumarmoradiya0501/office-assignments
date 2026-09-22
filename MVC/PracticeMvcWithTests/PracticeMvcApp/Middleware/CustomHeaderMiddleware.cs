namespace PracticeMvcApp.Middleware;

public class CustomHeaderMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomHeaderMiddleware> _logger;

    public CustomHeaderMiddleware(RequestDelegate next, ILogger<CustomHeaderMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Middleware started: {Method} {Path}", context.Request.Method, context.Request.Path);
        context.Response.Headers.Append("X-Custom-Header", "Hello from middleware");

        await _next(context);

        _logger.LogInformation("Middleware ended: HTTP {StatusCode}", context.Response.StatusCode);
    }
}
