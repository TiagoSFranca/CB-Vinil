using CBVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBVinil.Persistence.EntityConfigurations
{
    public class CashbackParametroConfiguration : IEntityTypeConfiguration<CashbackParametro>
    {
        public void Configure(EntityTypeBuilder<CashbackParametro> builder)
        {
            builder.HasKey(e => e.IdCaskbackParametro);

            builder.Property(e => e.IdCaskbackParametro)
                .ValueGeneratedNever();

            builder.Property(e => e.Percentual)
                .IsRequired();

            builder.HasOne(e => e.DiaSemana)
                .WithMany(p => p.CashbackParametros)
                .HasForeignKey(e => e.IdDiaSemana)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.GeneroMusical)
                .WithMany(p => p.CashbackParametros)
                .HasForeignKey(e => e.IdGeneroMusical)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
