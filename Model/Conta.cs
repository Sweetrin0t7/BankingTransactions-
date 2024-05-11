
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankCrud.Model
{
    public class Conta
    {
        public int ContaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Senha { get; set; }

        public decimal Saldo { get; set; }

        public virtual ICollection<Transacao> TransacoesOrigem { get; set; }
        public virtual ICollection<Transacao> TransacoesDestino { get; set; }
    }
}
