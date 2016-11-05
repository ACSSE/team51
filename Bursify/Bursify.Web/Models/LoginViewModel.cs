using System.ComponentModel.DataAnnotations;

namespace Bursify.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
        
    }
}