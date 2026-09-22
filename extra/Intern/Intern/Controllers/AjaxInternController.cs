using Intern.Models;
using Intern.Services;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Collections.Generic;

namespace Intern.Controllers;

public class AjaxInternController : Controller
{
    // GET: AjaxInternController
    private readonly InternHelper _internHelper;

    public AjaxInternController(NpgsqlConnection connection)
    {
        _internHelper = new InternHelper(connection);
    }
        public ActionResult Index()
        {
            ViewBag.Topics = _internHelper.FetchAllTopics();
            return View();
        }


        [HttpGet]
        public JsonResult GetAllInterns()
        {   
            var interns = _internHelper.FetchAllInterns();
                return Json(interns);
        }

        //GET BY ID
        [HttpGet]
        public JsonResult GetInternDetails(int id)
        {
            var intern = _internHelper.FetchInternDetails(id);
            
                if(intern == null)
            {
                return Json(new{success = false , message = "intern not found"});
            }
            return Json(intern);
        }

        [HttpPost]
        public JsonResult AddIntern([FromForm] InterClass i)
        {
            // Field validation is intentionally disabled for this training project.

            if (i.TopicImageFile is { Length: > 0 })
            {
                i.TopicImage = _internHelper.SaveImage(i.TopicImageFile);
            }

            _internHelper.AddNewIntern(i);
            return Json(new{success = true , message = "add complete"});
        }

        [HttpPost]
        public JsonResult UpdateIntern([FromForm] InterClass intern)
        {
            var existingIntern = _internHelper.FetchInternDetails(intern.InternId);
            if (existingIntern == null)
            {
                return Json(new { success = false, message = "Intern not found." });
            }

            // Field validation is intentionally disabled for this training project.

            if (intern.TopicImageFile is { Length: > 0 })
            {
                intern.TopicImage = _internHelper.SaveImage(intern.TopicImageFile);
                _internHelper.DeleteImage(existingIntern.TopicImage);
            }
            else
            {
                // Do not clear the existing image when the edit form has no new file.
                intern.TopicImage = existingIntern.TopicImage;
            }

            _internHelper.UpdateExistingIntern(intern);
            return Json(new { success = true, message = "Intern updated successfully." });
        }

        [HttpPost]
        public JsonResult DeleteIntern(int id)
        {
            try
            {
                var intern = _internHelper.FetchInternDetails(id);


                if (intern == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Intern not found."
                    });
                }


                _internHelper.DeleteExistingIntern(id);


                

            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false,
                    message = "The intern could not be deleted."
                });
            }

            return Json(new
                {
                    success = true,
                    message = "Intern deleted successfully."
                });

            
        }
    }

