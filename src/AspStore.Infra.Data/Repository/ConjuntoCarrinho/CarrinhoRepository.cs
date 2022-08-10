using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Interfaces.Repository.ConjuntoCarrinho;
using AspStore.Entities;
using AspStore.Infra.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.Repository.ConjuntoCarrinho
{
    public class CarrinhoRepository : GenericRepository<Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(AspStoreDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Carrinho> ObterCarrinhoComProduto(string CPF)
        {
            return await _context.Carrinho
                .Include(p => p.ProdutoCarrinho)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CPF.NumeroCPF == CPF);
        }

        public async Task SalvarProdutoNoCarrinho(Cliente cliente, ProdutoCarrinho produtoCarrinho)
        {
            produtoCarrinho.CarrinhoId = cliente.CarrinhoId;
            produtoCarrinho.Produto = null;
            _context.ProdutoCarrinho.Add(produtoCarrinho);         
        }
    }
}
