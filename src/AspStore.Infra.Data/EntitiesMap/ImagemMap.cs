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

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Caminho).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Principal).IsRequired();

            builder.HasOne(r => r.Produto).WithMany().HasForeignKey(f => f.ProdutoId);
        }
    }
}
