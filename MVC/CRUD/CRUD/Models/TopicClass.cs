using System.ComponentModel.DataAnnotations;

namespace Crud_Ajax.Models
{
    public class TopicClass
    {
        [Required(ErrorMessage = "Topic Id is required")]
        [Display(Name = "Topic ID")]
        public int? TopicId { get; set; } // Corresponds to c_TopicId in the database

        [Required(ErrorMessage = "Topic Name is required")]
        [StringLength(100, ErrorMessage = "Topic Name can't exceed 100 characters")]
        [Display(Name = "Topic Name")]
        public string? TopicName { get; set; } // Corresponds to c_TopicName in the database
    }
}
