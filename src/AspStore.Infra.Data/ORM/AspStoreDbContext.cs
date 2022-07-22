using Microsoft.EntityFrameworkCore;

namespace AspStore.Infra.Data.ORM
{
    public class AspStoreDbContext : DbContext
    {
        public AspStoreDbContext(DbContextOptions<AspStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AspStoreDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
