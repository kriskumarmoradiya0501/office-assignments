using Microsoft.AspNetCore.Mvc;
using Crud_Ajax.BAL;
using Crud_Ajax.Models;
using Npgsql;
using System.Collections.Generic;
using System.IO;

namespace Crud_Ajax.Controllers
{
    public class MVCInternController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly InternHelper _internHelper;

        public MVCInternController(IWebHostEnvironment webHostEnvironment, InternHelper internHelper)
        {
            _webHostEnvironment = webHostEnvironment;
            _internHelper = internHelper;
        }

        // GET: Fetch and display all interns
        public IActionResult GetAll()
        {
            List<InternClass> interns = _internHelper.FetchAllInterns();
            ViewBag.Topics = _internHelper.FetchAllTopics();
            return View(interns); // Returns a view that displays all interns
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            return Json(_internHelper.FetchAllInterns());
        }

        // GET: Display a form for adding a new intern
        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Topics = _internHelper.FetchAllTopics(); // Populate topics for dropdown
            return View();
        }

        // POST: Add a new intern
        [HttpPost]
        public IActionResult Insert(InternClass intern)
        {
            if (intern.TopicImageFile != null && intern.TopicImageFile.Length > 0)
            {
                intern.TopicImage = SaveImage(intern.TopicImageFile);
            }
            if (ModelState.IsValid)
            {
                _internHelper.AddNewIntern(intern); // Call helper to add the intern
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = true, message = "Intern added successfully." });
                }
                TempData["SuccessMessage"] = "Intern added successfully!";
                return RedirectToAction("GetAll"); // Redirect back to list after adding
            }
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return BadRequest(new { success = false, errors = ModelStateErrors() });
            }
            ViewBag.Topics = _internHelper.FetchAllTopics();
            return View(intern); // Stay on the form if validation fails
        }

        // GET: Fetch and display details of a single intern
        public IActionResult GetDetail(int id)
        {
            InternClass intern = _internHelper.FetchInternDetails(id);
            if (intern == null)
            {
                return NotFound(); // Return 404 if intern not found
            }
            return View(intern); // Returns a view displaying intern details
        }

        [HttpGet]
        public IActionResult GetDetailData(int id)
        {
            var intern = _internHelper.FetchInternDetails(id);
            return intern == null ? NotFound() : Json(intern);
        }

        // GET: Display form for updating an intern's data
        [HttpGet]
        public IActionResult Update(int id)
        {
            InternClass intern = _internHelper.FetchInternDetails(id);
            if (intern == null)
            {
                return NotFound(); // Return 404 if intern not found
            }
            ViewBag.Topics = _internHelper.FetchAllTopics(); // Populate topics for dropdown
            return View(intern); // Return a form for updating
        }

        // POST: Update intern data
        [HttpPost]
        public IActionResult Update(InternClass intern)
        {
            // Get the existing intern from DB
            var existingIntern = _internHelper.FetchInternDetails(intern.InternId);
            if (intern.TopicImageFile != null && intern.TopicImageFile.Length > 0)
            {
                // delete old file if exists
                if (!string.IsNullOrEmpty(existingIntern?.TopicImage))
                {
                    var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", existingIntern.TopicImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                        Console.WriteLine($"✅ Old image deleted: {oldPath}");
                    }
                    else
                    {
                        Console.WriteLine($"⚠️ Old image not found: {oldPath}");
                    }
                }
                // save new image
                intern.TopicImage = SaveImage(intern.TopicImageFile);
                Console.WriteLine($"📸 New image saved: {intern.TopicImage}");
            }
            else
            {
                // keep old image
                intern.TopicImage = existingIntern?.TopicImage;
            }

            if (ModelState.IsValid)
            {
                _internHelper.UpdateExistingIntern(intern);
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = true, message = "Intern updated successfully." });
                }
                TempData["SuccessMessage"] = "Intern Updated successfully!";
                return RedirectToAction("GetAll");
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return BadRequest(new { success = false, errors = ModelStateErrors() });
            }

            // Repopulate topics if validation fails
            ViewBag.Topics = _internHelper.FetchAllTopics();
            return View(intern);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var intern = _internHelper.FetchInternDetails(id);
            return View(intern);
        }

        // POST: Delete an intern
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _internHelper.DeleteExistingIntern(id); // Call helper to delete the intern
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = true, message = "Intern deleted successfully." });
            }
            return RedirectToAction("GetAll"); // Redirect back to list after deletion
        }

        private object ModelStateErrors()
        {
            return ModelState
                .Where(entry => entry.Value?.Errors.Count > 0)
                .ToDictionary(
                    entry => entry.Key,
                    entry => entry.Value!.Errors.Select(error => error.ErrorMessage).ToArray());
        }

        // ---------- IMAGE SAVE ----------
        private string SaveImage(IFormFile file)
        {
            var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            // var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            // var filePath = Path.Combine(uploads, uniqueFileName);

            var FileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploads, FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // store only relative path in DB
            // return uniqueFileName;
            // return "/images/" + uniqueFileName;

            return FileName;
        }
    }
}
