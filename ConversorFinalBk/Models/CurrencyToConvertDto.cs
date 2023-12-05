using System.ComponentModel.DataAnnotations;

namespace ConversorFinalBk.Models
{
    public class CurrencyToConvertDto
    {
        [Required]
        int amount { get; set; }

        [Required]
        public int CurrencyFromId { get; set; }

        [Required]
        public int CurrencyToId { get; set; }
    }
}
