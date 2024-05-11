using Microsoft.EntityFrameworkCore;
using BankCrud.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankCrud.Data
{
    public class BancoDadosContexto : DbContext
    {
        
        public BancoDadosContexto(DbContextOptions<BancoDadosContexto> options) : base(options)
        {
        }

        public DbSet<Conta> Conta => Set<Conta>();
        public DbSet<Transacao> Transacao => Set<Transacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.ContaOrigem)
                .WithMany(c => c.TransacoesOrigem)
                .HasForeignKey(t => t.ContaOrigemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.ContaDestino)
                .WithMany(c => c.TransacoesDestino)
                .HasForeignKey(t => t.ContaDestinoId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
