using AspStore.Domain.Entities.ConjuntoPedido;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services.ConjutoPedido
{
    public interface IPedidoDomainService : IGenericDomainService<Pedido>
    {
        Task<Pedido> ObterPedidoComProdutos(int PedidoId);
    }
}
