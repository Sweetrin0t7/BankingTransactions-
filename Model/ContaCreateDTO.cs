using System.ComponentModel.DataAnnotations;

namespace BankCrud.Model
{
    public class ContaCreateDTO
    {

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Senha { get; set; }
    }
}
