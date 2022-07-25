using AspStore.Domain.Entities.ConjuntoCarrinho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AspStore.Infra.Data.EntitiesMap
{
    public class ProdutoCarrinhoMap : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Quantidade)
                   .IsRequired();

            builder.Property(p => p.Preco)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.HasOne(r => r.Produto).WithOne().HasForeignKey<Carrinho>(f => f.ProdutoId);

            builder.HasOne(r => r.Carrinho).WithMany(r => r.ProdutoCarrinho).HasForeignKey(f => f.CarrinhoId);
        }
    }
}
