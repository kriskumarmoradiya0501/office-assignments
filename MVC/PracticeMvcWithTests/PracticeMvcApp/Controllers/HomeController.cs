using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticeMvcApp.Models;
using PracticeMvcApp.Services;

namespace PracticeMvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CalculatorService _calculatorService;
    private readonly PasswordValidator _passwordValidator;

    public HomeController(
        ILogger<HomeController> logger,
        CalculatorService calculatorService,
        PasswordValidator passwordValidator)
    {
        _logger = logger;
        _calculatorService = calculatorService;
        _passwordValidator = passwordValidator;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Demo()
    {
        var result = _calculatorService.Add(5, 7);
        ViewData["Result"] = $"The service calculated 5 + 7 = {result}.";
        return View("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CheckPassword(string password)
    {
        var hasMinimumLength = _passwordValidator.HasMinimumLength(password);
        var hasCapitalLetter = _passwordValidator.HasCapitalLetter(password);
        var hasNumber = _passwordValidator.HasNumber(password);

        ViewData["PasswordLengthCheck"] = hasMinimumLength;
        ViewData["PasswordCapitalCheck"] = hasCapitalLetter;
        ViewData["PasswordNumberCheck"] = hasNumber;
        ViewData["PasswordIsValid"] = hasMinimumLength && hasCapitalLetter && hasNumber;

        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
