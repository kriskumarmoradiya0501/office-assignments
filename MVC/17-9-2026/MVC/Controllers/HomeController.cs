using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserInterface _userRepo;

    public HomeController(ILogger<HomeController> logger, IUserInterface userRepo)
    {
        _logger = logger;
        _userRepo = userRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(vm_Login login)
    {
        t_User UserData = await _userRepo.Login(login);
        if (ModelState.IsValid)
        {
            if (UserData.c_UserId != 0)
            {
               HttpContext.Session.SetInt32("UserId", UserData.c_UserId);
               HttpContext.Session.SetString("UserName", UserData.c_UserName);
               return RedirectToAction("List","Contact");
            }
            else
            {
                ViewData["message"] = "Invalid Username and Password";
            }
        }
        return View(login);
    }
    
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(t_User user)
    {
        if (ModelState.IsValid)
        {
            if (user.ProfilePicture != null && user.ProfilePicture.Length > 0)
            {
                // Save the uploaded file
                var fileName = user.c_Email + Path.GetExtension(user.ProfilePicture.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile_images", fileName);
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile_images"));
                user.c_Image = fileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    user.ProfilePicture.CopyTo(stream);
                }
            }
            Console.WriteLine("user.c_fname: " + user.c_UserName);
            var status = await _userRepo.Register(user);
            if (status == 1)
            {
                ViewData["message"] = "User Registred";
                return RedirectToAction("Login");
            }
            else if (status == 0)
            {
                ViewData["message"] = "User Already Registred";
            }
            else
            {
                ViewData["message"] = "There was some error while Registration";
            }
        }
        return View(user);
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
