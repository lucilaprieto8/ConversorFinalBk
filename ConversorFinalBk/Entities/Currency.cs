using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConversorFinalBk.Entities
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Leyend { get; set; }

        [Required]
        public string Symbol { get; set; }

        [Required]
        public double IC { get; set; }
    }
}
