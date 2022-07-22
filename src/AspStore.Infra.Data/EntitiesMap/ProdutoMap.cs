using AspStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.EntitiesMap
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Preco)
                   .HasPrecision(10, 2);

            builder.Property(p => p.Estoque)
                   .IsRequired();

            builder.HasOne(e => e.Categoria).WithMany(e => e.Produto)
            .HasForeignKey(e => e.CategoriaId);

        }
    }
}
