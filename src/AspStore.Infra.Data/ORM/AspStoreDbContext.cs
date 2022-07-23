using AspStore.Domain.Entities;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Entities;
using Microsoft.EntityFrameworkCore;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AspStoreDbContext).Assembly);
        }
    }
}
