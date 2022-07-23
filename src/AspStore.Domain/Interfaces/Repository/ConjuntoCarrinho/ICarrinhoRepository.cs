using AspStore.Domain.Entities.ConjuntoCarrinho;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository.ConjuntoCarrinho
{
    public interface ICarrinhoRepository : IGenericRepository<Carrinho>
    {
        Task<Carrinho> ObterCarrinhoComProduto(int ClienteId);
    }
}
