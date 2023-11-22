using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorFinal_BE.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Subscription Subscription { get; set; }

        public int IdSubscription { get; set; }

        public IEnumerable<Conversion> conversions { get; set; }

    }
}
