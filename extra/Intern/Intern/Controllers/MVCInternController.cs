using Intern.Models;
using Intern.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intern.Controllers;

public class MVCInternController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly InternHelper _internHelper;

    public MVCInternController(IWebHostEnvironment webHostEnvironment, InternHelper internHelper)
    {
        _webHostEnvironment = webHostEnvironment;
        _internHelper = internHelper;
    }

    public IActionResult GetAll()
    {
        return View(_internHelper.FetchAllInterns());
    }

    [HttpGet]
    public IActionResult Insert()
    {
        ViewBag.Topics = _internHelper.FetchAllTopics();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Insert(InterClass intern)
    {
        // ModelState validation is intentionally disabled for this training project.

        if (intern.TopicImageFile is { Length: > 0 })
        {
            intern.TopicImage = SaveImage(intern.TopicImageFile);
        }

        _internHelper.AddNewIntern(intern);
        TempData["SuccessMessage"] = "Intern added successfully!";
        return RedirectToAction(nameof(GetAll));
    }

    public IActionResult GetDetail(int id)
    {
        var intern = _internHelper.FetchInternDetails(id);
        return intern is null ? NotFound() : View(intern);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var intern = _internHelper.FetchInternDetails(id);
        if (intern is null)
        {
            return NotFound();
        }

        ViewBag.Topics = _internHelper.FetchAllTopics();
        return View(intern);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(InterClass intern)
    {
        var existingIntern = _internHelper.FetchInternDetails(intern.InternId);
        if (existingIntern is null)
        {
            return NotFound();
        }

        // ModelState validation is intentionally disabled for this training project.

        if (intern.TopicImageFile is { Length: > 0 })
        {
            DeleteImage(existingIntern.TopicImage);
            intern.TopicImage = SaveImage(intern.TopicImageFile);
        }
        else
        {
            intern.TopicImage = existingIntern.TopicImage;
        }

        _internHelper.UpdateExistingIntern(intern);
        TempData["SuccessMessage"] = "Intern updated successfully!";
        return RedirectToAction(nameof(GetAll));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var intern = _internHelper.FetchInternDetails(id);
        return intern is null ? NotFound() : View(intern);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _internHelper.DeleteExistingIntern(id);
        TempData["SuccessMessage"] = "Intern deleted successfully!";
        return RedirectToAction(nameof(GetAll));
    }

    private string SaveImage(IFormFile file)
    {
        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        Directory.CreateDirectory(uploads);

        var fileName = $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploads, fileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(stream);
        return fileName;
    }

    private void DeleteImage(string? fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return;
        }

        var safeFileName = Path.GetFileName(fileName);
        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", safeFileName);
        if (System.IO.File.Exists(imagePath))
        {
            System.IO.File.Delete(imagePath);
        }
    }
}
