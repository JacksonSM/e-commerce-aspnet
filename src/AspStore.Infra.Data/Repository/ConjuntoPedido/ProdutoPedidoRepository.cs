using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Domain.Interfaces.Repository.ConjuntoPedido;
using AspStore.Infra.Data.ORM;

namespace AspStore.Infra.Data.Repository.ConjuntoPedido
{
    public class ProdutoPedidoRepository : GenericRepository<ProdutoPedido>, IProdutoPedidoRepository
    {
        public ProdutoPedidoRepository(AspStoreDbContext context) : base (context)
        {
            _context = context;
        }
    }
}
