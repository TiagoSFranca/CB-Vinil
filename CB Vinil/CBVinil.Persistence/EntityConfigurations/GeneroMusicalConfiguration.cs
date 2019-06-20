using CBVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBVinil.Persistence.EntityConfigurations
{
    public class GeneroMusicalConfiguration : IEntityTypeConfiguration<GeneroMusical>
    {
        public void Configure(EntityTypeBuilder<GeneroMusical> builder)
        {
            builder.HasKey(e => e.IdGeneroMusical);

            builder.Property(e => e.IdGeneroMusical)
                .ValueGeneratedNever();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.ArgSpotify)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
