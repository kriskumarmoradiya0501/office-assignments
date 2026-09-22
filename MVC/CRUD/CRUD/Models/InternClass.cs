using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Required for IFormFile

namespace Crud_Ajax.Models
{
    public class InternClass
    {
        [Display(Name = "Intern ID")]
        public int InternId { get; set; } // Corresponds to c_InternId in the database

        [Required(ErrorMessage = "Intern Name is required")]
        [StringLength(100, ErrorMessage = "Intern Name can't exceed 100 characters")]
        [Display(Name = "Intern Name")]
        public string? InternName { get; set; } // Corresponds to c_InternName in the database

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("M|F", ErrorMessage = "Gender must be 'M' for Male or 'F' for Female")]
        [Display(Name = "Gender")]
        public string? Gender { get; set; } // Corresponds to c_Gender (Radio button: 'M' or 'F')

        [Required(ErrorMessage = "Presentation Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Presentation")]
        public DateOnly DateOfPresentation { get; set; } // Corresponds to c_Date_Of_Presentation (Date)

        [Display(Name = "Presentation Status")]
        public bool Status { get; set; } // Corresponds to c_Status (Checkbox: true for Presented)

        public string? TopicImage { get; set; } = ""; // Corresponds to c_Topic_Image (URL/Path for image)

        [Display(Name = "Upload Topic Image")]
        // [Required(ErrorMessage = "Image is required")]
        public IFormFile? TopicImageFile { get; set; } // Used to upload image files

        // Optional: Relationship to the TopicClass
        [Required(ErrorMessage = "Topic selection is required")]
        public int? TopicId { get; set; } // Corresponds to c_TopicId (Foreign Key to TopicClass)

        public TopicClass? AssignedTopic { get; set; }
    }
}
