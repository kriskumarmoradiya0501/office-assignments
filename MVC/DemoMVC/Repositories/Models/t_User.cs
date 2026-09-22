using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Repositories
{
    public class t_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_userid { get; set; }

        [Required]
        [StringLength(100)]
        public string c_username { get; set; } = "";

        [Required]
        [EmailAddress]
        public string c_email { get; set; } = "";

        [Required]
        [MinLength(6)]
        public string c_password { get; set; } = "";

        [Compare("c_password")]
        public string c_c_password { get; set; } = "";

        public string? c_address { get; set; }

        public string? c_mobile { get; set; }

        public string? c_gender { get; set; }

        public string? c_image { get; set; }

        [NotMapped]
        public IFormFile? ProfilePicture { get; set; }
    }
}