using CBVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CBVinil.Persistence
{
    public class CBVinilContext : DbContext
    {
        public CBVinilContext(DbContextOptions<CBVinilContext> options)
            : base(options)
        {
        }

        #region Entities

        public DbSet<GeneroMusical> GeneroMusical { get; set; }
        public DbSet<DiaSemana> DiaSemana { get; set; }
        public DbSet<CashbackParametro> CashbackParametro { get; set; }
        public DbSet<Disco> Disco { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CBVinilContext).Assembly);
        }
    }
}
