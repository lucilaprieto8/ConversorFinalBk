using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorFinalBk.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public Subscription Subscription { get; set; }

        public int IdSubscription { get; set; } = 1;

        public IEnumerable<ConversionHistory> ConversionHistory { get; set; }

        public User()
        {
            ConversionHistory = new List<ConversionHistory>();
        }
    }
}
