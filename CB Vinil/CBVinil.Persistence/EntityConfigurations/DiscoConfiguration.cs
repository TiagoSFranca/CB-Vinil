using CBVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBVinil.Persistence.EntityConfigurations
{
    public class DiscoConfiguration : IEntityTypeConfiguration<Disco>
    {
        public void Configure(EntityTypeBuilder<Disco> builder)
        {
            builder.HasKey(e => e.IdDisco);

            builder.Property(e => e.IdDisco)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.Preco)
                .IsRequired();

            builder.HasOne(e => e.GeneroMusical)
                .WithMany(p => p.Discos)
                .HasForeignKey(e => e.IdGeneroMusical)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
