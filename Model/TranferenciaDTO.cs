using System.ComponentModel.DataAnnotations;

namespace BankCrud.Model
{
    public class TransferenciaDTO
    {
        [Required]
        public int ContaOrigemId { get; set; }

        [Required]
        public int ContaDestinoId { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
