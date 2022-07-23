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


            builder.HasOne(r => r.Cliente).WithOne(r => r.Carrinho).HasForeignKey<Carrinho>(f => f.ClienteId);

        }
    }
}
