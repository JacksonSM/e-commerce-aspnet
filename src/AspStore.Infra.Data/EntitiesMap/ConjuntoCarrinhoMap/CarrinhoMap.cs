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


          
        }
    }
}
