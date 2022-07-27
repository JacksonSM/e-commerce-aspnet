using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Interfaces.Repository.ConjuntoCarrinho;
using AspStore.Infra.Data.ORM;

namespace AspStore.Infra.Data.Repository.ConjuntoCarrinho
{
    public class ProdutoCarrinhoRepository : GenericRepository<ProdutoCarrinho>, IProdutoCarrinhoRepository
    {
        public ProdutoCarrinhoRepository(AspStoreDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
