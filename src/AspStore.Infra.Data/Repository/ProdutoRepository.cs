using AspStore.Domain.Entities;
using AspStore.Domain.Interfaces.Repository;
using AspStore.Infra.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.Repository
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AspStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GerarCodigoInterno()
        {
            
            if ( _context.Produto.Count() > 0)
            {
                return _context.Produto.Max(p => p.CodigoInterno) + 1;
            }
            return 0; 
        }

        public Task<Produto> ObterProdutoComCategoria(int produtoId)
        {
            return _context.Produto.Include(e => e.Categoria).AsNoTracking().FirstOrDefaultAsync(x => x.Id == produtoId);
        }
    

        public async Task<IEnumerable<Produto>> TodosProdutoComCategoria()
        {
            return  _context.Produto.Include(c => c.Categoria).AsNoTracking().AsEnumerable();
        }
    }
}
