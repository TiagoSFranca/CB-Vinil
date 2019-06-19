using CBVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBVinil.Persistence.EntityConfigurations
{
    public class DiaSemanaConfiguration : IEntityTypeConfiguration<DiaSemana>
    {
        public void Configure(EntityTypeBuilder<DiaSemana> builder)
        {
            builder.HasKey(e => e.IdDiaSemana);

            builder.Property(e => e.IdDiaSemana)
                .ValueGeneratedNever();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.DiaDaSemana)
                .IsRequired();
        }
    }
}
