using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankCrud.Model
{
    public class Transacao
    {
        [Key]
        public int TransacaoId { get; set; }

        public DateTime Data { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        [StringLength(255)]
        public string Tipo { get; set; }

        public int ContaOrigemId { get; set; }

        public int ContaDestinoId { get; set; }

        [ForeignKey("ContaOrigemId")]
        public virtual Conta ContaOrigem { get; set; }

        [ForeignKey("ContaDestinoId")]
        public virtual Conta ContaDestino { get; set; }
    }
}
