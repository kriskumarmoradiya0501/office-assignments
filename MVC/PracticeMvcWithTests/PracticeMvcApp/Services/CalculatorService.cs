namespace PracticeMvcApp.Services;

public class CalculatorService
{
    private readonly ILogger<CalculatorService> _logger;

    public CalculatorService(ILogger<CalculatorService> logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        _logger.LogInformation("Service started: adding {FirstNumber} + {SecondNumber}", a, b);
        var result = a + b;
        _logger.LogInformation("Service ended: result is {Result}", result);
        return result;
    }
}
