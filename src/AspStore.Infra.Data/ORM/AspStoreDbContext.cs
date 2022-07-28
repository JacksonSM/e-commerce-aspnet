using AspStore.Domain.Entities;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AspStore.Infra.Data.ORM
{
    public class AspStoreDbContext : DbContext
    {
        public AspStoreDbContext(DbContextOptions<AspStoreDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ProdutoPedido> ProdutoPedido { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<ProdutoCarrinho> ProdutoCarrinho { get; set; }
        public DbSet<Imagem> Imagem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AspStoreDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
