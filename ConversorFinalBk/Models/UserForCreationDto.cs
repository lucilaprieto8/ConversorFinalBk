using System.ComponentModel.DataAnnotations;

namespace ConversorFinalBk.Models
{
    public class UserForCreationDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public int IdSubscription { get; set; } = 1;

    }
}
