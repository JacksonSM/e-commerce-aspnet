using AspStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspStore.Infra.Data.EntitiesMap
{
    class ImagemMap : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.HasKey(p => p.Id);

            
            builder.Property(p => p.Caminho).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Principal).IsRequired();

        }
    }
}
