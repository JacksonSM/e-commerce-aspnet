using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService.ConjutoCarrinho
{
    public interface ICarrinhoAppService : IGenericAppService<CarrinhoViewModel, Carrinho>
    {
        Task<CarrinhoViewModel> ObterCarrinhoComProduto(int ClienteId);
    }
}
