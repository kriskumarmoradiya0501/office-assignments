using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoActionResult.Controllers
{
    public class ActionResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            var student = new
            {
                Name = "Krish",
                Age = 20,
                Cource = "MCA"
            };

            return View(student);
        }
    }
}