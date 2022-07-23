using AspStore.Domain.Entities.ConjuntoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspStore.Infra.Data.EntitiesMap
{
    public class ProdutoPedidoMap : IEntityTypeConfiguration<ProdutoPedido>
    {
        public void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.PrecoUnidade)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.Quantidade)
                   .IsRequired();

            builder.HasOne(r => r.Produto).WithOne().HasForeignKey<ProdutoPedido>(f => f.ProdutoId);
            


        }
    }
}
