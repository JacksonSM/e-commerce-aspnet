using AspStore.Domain.Entities.ConjuntoCarrinho;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services.ConjutoCarrinho
{
    public interface ICarrinhoDomainService : IGenericDomainService<Carrinho>
    {
        Task<Carrinho> ObterCarrinhoComProduto(int ClienteId);
    }
}
