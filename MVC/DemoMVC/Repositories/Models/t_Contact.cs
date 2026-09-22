using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Repositories
{
    public class t_Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_contactid { get; set; }

        public int c_userid { get; set; }

        [Required]
        [StringLength(100)]
        public string c_name { get; set; }

        [Required]
        [EmailAddress]
        public string c_email { get; set; }

        public string? c_group { get; set; }

        public string? c_address { get; set; }

        public string? c_mobile { get; set; }

        public string? c_image { get; set; }

        public bool c_status { get; set; }

        [NotMapped]
        public IFormFile? ContactPicture { get; set; }
    }
}