using AspStore.Domain.Entities.ConjuntoPedido;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository.ConjuntoPedido
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        Task<Pedido> ObterPedidoComProdutos(int PedidoId);
    }
}
