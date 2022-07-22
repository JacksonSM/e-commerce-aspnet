using AspStore.Domain.Entities.ConjuntoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspStore.Infra.Data.EntitiesMap
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.TipoEndereco)
                   .IsRequired();

            builder.Property(p => p.Logradouro)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Bairro)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Cidade)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Estado)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.OwnsOne(p => p.CEP)
                   .Property(p => p.Numero)
                   .IsRequired();

        }
    }
}
