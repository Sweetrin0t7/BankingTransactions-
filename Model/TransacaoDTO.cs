namespace BankCrud.Model
{
    public class TransacaoDTO
    {
        public int TransacaoId { get; set; }
        public int ContaId { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
