using AspStore.Domain.Entities.ConjuntoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AspStore.Infra.Data.EntitiesMap
{
    class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ValorTotal)
                   .HasPrecision(10, 2);
            builder.Property(p => p.ValorEnvio)
                   .HasPrecision(10, 2);


            builder.HasOne(r => r.Cliente).WithMany(r => r.Pedido).HasForeignKey(f => f.ClienteId);

            builder.HasOne(r => r.Endereco).WithOne().HasForeignKey<Pedido>(f => f.EnderecoId);

            builder.HasMany(r => r.ProdutoPedido).WithOne().HasForeignKey(f => f.PedidoId);
        }
    }
}
