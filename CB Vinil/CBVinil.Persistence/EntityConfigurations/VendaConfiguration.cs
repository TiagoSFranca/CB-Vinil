using CBVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBVinil.Persistence.EntityConfigurations
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(e => e.IdVenda);

            builder.Property(e => e.IdVenda)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ValorCashback)
                .IsRequired();

            builder.Property(e => e.ValorEfetivo)
                .IsRequired();

            builder.Property(e => e.ValorTotal)
                .IsRequired();

            builder.Property(e => e.DataVenda)
                .IsRequired();
        }
    }
}
