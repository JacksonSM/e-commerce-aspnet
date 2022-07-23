using AspStore.Domain.Entities.ConjuntoCarrinho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AspStore.Infra.Data.EntitiesMap
{
    public class ProdutoCarrinhoMap : IEntityTypeConfiguration<ProdutoCarrinho>
    {
        public void Configure(EntityTypeBuilder<ProdutoCarrinho> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Quantidade)
                   .IsRequired();

            builder.Property(p => p.Preco)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.HasOne(r => r.Produto).WithOne().HasForeignKey<ProdutoCarrinho>(f => f.ProdutoId);

            builder.HasOne(r => r.Carrinho).WithMany(r => r.ProdutoCarrinho).HasForeignKey(f => f.CarrinhoId);
        }
    }
}
