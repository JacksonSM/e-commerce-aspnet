using AspStore.Application.ViewModels.ConjutoPedido;
using AspStore.Domain.Entities.ConjuntoPedido;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService.ConjutoPedido
{
    public interface IPedidoAppService : IGenericAppService<PedidoViewModel,Pedido>
    {
        Task<PedidoViewModel> ObterPedidoComProdutos(int PedidoId);
    }
}
