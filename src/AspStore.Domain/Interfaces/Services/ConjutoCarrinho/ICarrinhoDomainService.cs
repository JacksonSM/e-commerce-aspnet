using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services.ConjutoCarrinho
{
    public interface ICarrinhoDomainService : IGenericDomainService<Carrinho>
    {
        Task<Carrinho> ObterCarrinhoComProduto(int ClienteId);
        Task SalvarProdutoNoCarrinho(Cliente cliente, ProdutoCarrinho produtoCarrinho);
    }
}
