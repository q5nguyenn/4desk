using System.ComponentModel.DataAnnotations;

namespace _4Desk_OHD.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(6)]
        public string Password { get; set; } = string.Empty;

    }
}
