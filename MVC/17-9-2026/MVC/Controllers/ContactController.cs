using Microsoft.AspNetCore.Mvc;
using Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers;

public class ContactController : Controller
{
    private readonly IContactInterface _contact;
    private readonly IUserInterface _userRepo;
    public ContactController(IContactInterface contact, IUserInterface userRepo)
    {
        _contact = contact;
        _userRepo = userRepo;
    }
    
    public async Task<ActionResult> Index()
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            t_User UserData = await _userRepo.GetUser((int)HttpContext.Session.GetInt32("UserId"));
            return View(UserData);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }
    
    public ActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }

    public async Task<ActionResult> List()
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            List<t_Contact> contacts = await _contact.GetAllByUser(HttpContext.Session.GetInt32("UserId").ToString());
            return View(contacts);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }
    
    [HttpGet]
    public async Task<ActionResult> Create(string id="")
    {
        t_Contact contact = new t_Contact();
        if(id != "")
        {
             contact = await _contact.GetOne(id);
        }
        return View(contact);
    }

    [HttpPost]
    public async Task<ActionResult> Create(t_Contact contact)
    {
        if (ModelState.IsValid)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (contact.ContactPicture != null && contact.ContactPicture.Length > 0)
                {
                    var fileName = contact.c_Email + Path.GetExtension(contact.ContactPicture.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "contact_images", fileName);
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "contact_images"));
                    contact.c_Image = fileName;
                    if(System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        contact.ContactPicture.CopyTo(stream);
                    }
                }
                contact.c_UserId = (int)HttpContext.Session.GetInt32("UserId");
                var result = 0;

                if(contact.c_ContactId == 0)
                {
                     result = await _contact.Add(contact);
                }
                else
                {
                     result = await _contact.Update(contact);
                }
                if (result == 0)
                {
                    TempData["Message"] = "There Is Some Error while Add or Update Contact";
                    return RedirectToAction("List", "Contact");
                }
                else
                {
                    TempData["Message"] = "Contact Added/Updated Successfully";
                    return RedirectToAction("List", "Contact");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View(contact);
    }
    
    [HttpGet]
    public async Task<ActionResult> Delete(string id)
    {
        int status = await _contact.Delete(id);
        if (status == 1)
        {
            TempData["Message"] = "Contact Deleted Successfully";
            return RedirectToAction("List");
        }
        else
        {
            TempData["Message"] = "There Is Some Error while Delete Contact";
            return RedirectToAction("List");
        }
    }
}
