using BankCrud.Data;
using BankCrud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BankCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private readonly BancoDadosContexto _context;

        public TransacoesController(BancoDadosContexto context)
        {
            _context = context;
        }

        // POST: api/Transacoes/Transferencia
        [HttpPost("Transferencia")]
        public async Task<ActionResult<TransacaoDTO>> PostTransferencia(TransferenciaDTO transferenciaDTO)
        {
            var contaOrigem = await _context.Conta.FindAsync(transferenciaDTO.ContaOrigemId);
            var contaDestino = await _context.Conta.FindAsync(transferenciaDTO.ContaDestinoId);

            if (contaOrigem == null || contaDestino == null)
            {
                return NotFound("Conta de origem ou conta de destino não encontrada.");
            }
            if (contaOrigem.Saldo < transferenciaDTO.Valor)
            {
                return BadRequest("Saldo insuficiente para a transferência.");
            }
            if (contaOrigem.Saldo <= 0)
            {
                return BadRequest("Saldo inválido para a transferência.");
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                contaOrigem.Saldo -= transferenciaDTO.Valor;
                contaDestino.Saldo += transferenciaDTO.Valor;

                _context.Transacao.Add(new Transacao
                {
                    Data = DateTime.Now,
                    Valor = transferenciaDTO.Valor,
                    Tipo = "Transferência",
                    ContaOrigemId = contaOrigem.ContaId,
                    ContaDestinoId = contaDestino.ContaId
                });

                await _context.SaveChangesAsync();
                transaction.Commit(); 

                var transacao = await _context.Transacao.OrderByDescending(t => t.TransacaoId).FirstOrDefaultAsync();

                var transacaoDTO = new TransacaoDTO
                {
                    TransacaoId = transacao.TransacaoId,
                    ContaId = contaOrigem.ContaId,
                    Tipo = "Transferência",
                    Valor = transferenciaDTO.Valor
                };

                return CreatedAtAction("GetTransacao", new { id = transacaoDTO.TransacaoId }, transacaoDTO);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest($"Erro na transferência: {ex.Message}");
            }
        }



        // GET: api/Transacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransacaoDTO>> GetTransacao(int id)
        {
            var transacao = await _context.Transacao.FindAsync(id);

            if (transacao == null)
            {
                return NotFound("Tranferência não encontrada.");
            }

            var transacaoDTO = new TransacaoDTO
            {
                TransacaoId = transacao.TransacaoId,
                ContaId = transacao.ContaOrigemId,
                Tipo = transacao.Tipo,
                Valor = transacao.Valor
            };

            return transacaoDTO;
        }
    }
}
