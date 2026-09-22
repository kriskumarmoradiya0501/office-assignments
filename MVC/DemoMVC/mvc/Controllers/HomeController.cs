using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Repositories;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly IUserInterface _userRepository;

    public HomeController(IUserInterface userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(vm_Login user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        var result = await _userRepository.Login(user);

        if (result != null)
        {
            HttpContext.Session.SetInt32("UserId", result.c_userid);
            HttpContext.Session.SetString("UserName", result.c_username);

            return RedirectToAction("Index", "Contact");
        }

        ViewBag.Message = "Invalid email or password";

        return View(user);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(t_User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        var result = await _userRepository.Register(user);

        if (result == 1)
        {
            TempData["Message"] = "Registration successful. Please login.";
            return RedirectToAction("Login");
        }
        else if (result == 0)
        {
            ViewBag.Message = "Email already exists.";
        }
        else
        {
            ViewBag.Message = "Something went wrong.";
        }

        return View(user);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
