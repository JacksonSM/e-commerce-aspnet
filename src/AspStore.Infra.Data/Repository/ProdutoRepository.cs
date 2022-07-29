using AspStore.Domain.Entities;
using AspStore.Domain.Interfaces.Repository;
using AspStore.Infra.Data.ORM;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.Repository
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AspStoreDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
