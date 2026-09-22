using Microsoft.AspNetCore.Mvc;
using MvcXunitDemo.Services;

namespace MvcXunitDemo.Controllers;

public class DemoController : Controller
{
    private readonly DemoService _demoService;

    public DemoController(DemoService demoService)
    {
        Console.WriteLine(">>> CONTROLLER CONSTRUCTOR");

        _demoService = demoService;
    }

    public IActionResult Index()
    {
        Console.WriteLine(">>> CONTROLLER ACTION START");

        string message = _demoService.GetMessage();

        Console.WriteLine("<<< CONTROLLER ACTION END");

        return Content(message);
    }
}