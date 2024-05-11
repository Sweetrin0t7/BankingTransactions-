using BankCrud.Data;
using BankCrud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly BancoDadosContexto _context;

        public ContasController(BancoDadosContexto context)
        {
            _context = context;
        }

        // POST: api/Contas
        [HttpPost]
        public async Task<ActionResult<ContaDTO>> PostConta(ContaCreateDTO contaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Conta novaConta = new Conta
            {
                Nome = contaDTO.Nome,
                Senha = contaDTO.Senha,
                Saldo = 0 // Saldo inicial pode ser definido aqui
            };

            _context.Conta.Add(novaConta);
            await _context.SaveChangesAsync();

            ContaDTO contaCriada = new ContaDTO
            {
                ContaId = novaConta.ContaId,
                Nome = novaConta.Nome,
                Saldo = novaConta.Saldo
            };

            return CreatedAtAction("GetConta", new { id = novaConta.ContaId }, contaCriada);
        }

        // GET: api/Contas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaDTO>>> GetContas()
        {
            List<ContaDTO> contas = await _context.Conta
                .Select(conta => new ContaDTO
                {
                    ContaId = conta.ContaId,
                    Nome = conta.Nome,
                    Saldo = conta.Saldo
                })
                .ToListAsync();

            return contas;
        }

        // GET: api/Contas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaDTO>> GetConta(int id)
        {
            var conta = await _context.Conta.FindAsync(id);

            if (conta == null)
            {
                return NotFound();
            }

            ContaDTO contaDTO = new ContaDTO
            {
                ContaId = conta.ContaId,
                Nome = conta.Nome,
                Saldo = conta.Saldo
            };

            return contaDTO;
        }
    }
}
