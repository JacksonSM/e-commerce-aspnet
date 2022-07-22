using AspStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AspStore.Infra.Data.EntitiesMap
{
    class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.OwnsOne(p => p.CPF)
                   .Property(p => p.NumeroCPF)
                   .IsRequired();

            builder.HasMany(r => r.Endereco).WithOne().HasForeignKey(r => r.ClienteId);
                                     
        }
    }
}
