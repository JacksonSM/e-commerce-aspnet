using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository.ConjuntoCarrinho
{
    public interface ICarrinhoRepository : IGenericRepository<Carrinho>
    {
        Task<Carrinho> ObterCarrinhoComProduto(int ClienteId);
        Task SalvarProdutoNoCarrinho(Cliente cliente,ProdutoCarrinho produtoCarrinho);
    }
}
