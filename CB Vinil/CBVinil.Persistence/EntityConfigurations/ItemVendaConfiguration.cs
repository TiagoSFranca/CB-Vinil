using CBVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBVinil.Persistence.EntityConfigurations
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.HasKey(e => e.IdItemVenda);

            builder.Property(e => e.IdItemVenda)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PercentualCashback)
                .IsRequired();

            builder.Property(e => e.PrecoUnitario)
                .IsRequired();

            builder.Property(e => e.Quantidade)
                .IsRequired();

            builder.Property(e => e.ValorCashback)
                .IsRequired();

            builder.Property(e => e.ValorEfetivo)
                .IsRequired();

            builder.Property(e => e.ValorTotal)
                .IsRequired();

            builder.HasOne(e => e.Venda)
                .WithMany(p => p.ItensVenda)
                .HasForeignKey(e => e.IdVenda)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Disco)
                .WithMany(p => p.ItensVenda)
                .HasForeignKey(e => e.IdDisco)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
