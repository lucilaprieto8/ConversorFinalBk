using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorFinalBk.Entities
{
    public class ConversionHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int CurrencyFrom { get; set; }

        public int CurrencyTo { get; set; }

        public int AmountInput { get; set; }

        public int AmountOutput { get; set; }

        public DateTime ConversionDate { get; set; }
        public User user { get; set; }
        public int IdUser { get; set; }
    }
}
