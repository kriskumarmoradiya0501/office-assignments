using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using PracticeMvcApp.Middleware;

namespace PracticeMvcApp.Tests;

public class CustomHeaderMiddlewareTests
{
    [Fact]
    public async Task InvokeAsync_AddsCustomHeader()
    {
        var context = new DefaultHttpContext();
        var middleware = new CustomHeaderMiddleware(
            _ => Task.CompletedTask,
            NullLogger<CustomHeaderMiddleware>.Instance);

        await middleware.InvokeAsync(context);

        Assert.Equal("Hello from middleware", context.Response.Headers["X-Custom-Header"]);
    }
}
