using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactInterface _contactRepository;
        private readonly IUserInterface _userRepository;

        public ContactController(
            IContactInterface contactRepository,
            IUserInterface userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var user = await _userRepository.GetUser(userid.Value);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> List()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var contacts = await _contactRepository.GetAllByUser(userid.Value);

            return View(contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(t_Contact contact)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            contact.c_userid = userid.Value;

            if (contact.ContactPicture != null)
            {
                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "profile_images"
                );

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName = Guid.NewGuid().ToString()
                                 + Path.GetExtension(contact.ContactPicture.FileName);

                string filePath = Path.Combine(folder, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await contact.ContactPicture.CopyToAsync(stream);
                }

                contact.c_image = fileName;
            }

            var result = await _contactRepository.Add(contact);

            if (result == 1)
            {
                TempData["Message"] = "Contact added successfully.";

                return RedirectToAction("List");
            }

            ViewBag.Message = "Something went wrong.";

            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var contact = await _contactRepository.GetOne(id);

            if (contact == null)
            {
                return NotFound();
            }

            if (contact.c_userid != userid.Value)
            {
                return Unauthorized();
            }

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(t_Contact contact)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            var existingContact = await _contactRepository.GetOne(contact.c_contactid);

            if (existingContact == null)
            {
                return NotFound();
            }

            if (existingContact.c_userid != userid.Value)
            {
                return Unauthorized();
            }

            if (contact.ContactPicture != null)
            {
                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "profile_images"
                );

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName = Guid.NewGuid().ToString()
                                 + Path.GetExtension(contact.ContactPicture.FileName);

                string filePath = Path.Combine(folder, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await contact.ContactPicture.CopyToAsync(stream);
                }

                contact.c_image = fileName;
            }
            else
            {
                contact.c_image = existingContact.c_image;
            }

            contact.c_userid = userid.Value;

            var result = await _contactRepository.Update(contact);

            if (result == 1)
            {
                TempData["Message"] = "Contact updated successfully.";

                return RedirectToAction("List");
            }

            ViewBag.Message = "Something went wrong.";

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");

            if (userid == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var contact = await _contactRepository.GetOne(id);

            if (contact == null)
            {
                return NotFound();
            }

            if (contact.c_userid != userid.Value)
            {
                return Unauthorized();
            }

            var result = await _contactRepository.Delete(id);

            if (result == 1)
            {
                TempData["Message"] = "Contact deleted successfully.";
            }
            else
            {
                TempData["Message"] = "Something went wrong.";
            }

            return RedirectToAction("List");
        }
    }
}