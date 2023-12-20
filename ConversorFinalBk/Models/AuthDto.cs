using System.ComponentModel.DataAnnotations;

namespace ConversorFinalBk.Models
{
    public class AuthDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
