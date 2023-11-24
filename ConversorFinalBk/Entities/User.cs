using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorFinalBk.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Subscription Subscription { get; set; }

        public int IdSubscription { get; set; }

        public IEnumerable<ConversionHistory> ConversionHistory { get; set; }

        public User()
        {
            ConversionHistory = new List<ConversionHistory>();
        }
    }
}
