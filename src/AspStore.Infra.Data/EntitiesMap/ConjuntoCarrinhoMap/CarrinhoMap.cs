using AspStore.Domain.Entities.ConjuntoCarrinho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspStore.Infra.Data.EntitiesMap
{
    class CarrinhoMap : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ProdutoCarrinho)
                   .IsRequired(false);

            builder.HasOne(r => r.Cliente).WithOne(r => r.Carrinho);

            builder.HasMany(r => r.ProdutoCarrinho).WithOne().HasForeignKey(r => r.CarrinhoId);
        }
    }
}
