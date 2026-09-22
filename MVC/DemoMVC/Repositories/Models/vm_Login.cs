using System.ComponentModel.DataAnnotations;

namespace Repositories;

public class vm_Login
{

    [Required]
    [EmailAddress]
    public string c_email{get; set;}

    [Required]
    public string c_password{get; set;}

}
