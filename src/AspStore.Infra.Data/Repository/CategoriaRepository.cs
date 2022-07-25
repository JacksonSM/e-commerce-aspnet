using AspStore.Domain.Interfaces.Repository;
using AspStore.Entities;
using AspStore.Infra.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AspStoreDbContext context): base (context)
        {
            _context = context;
        }
        public async Task<Categoria> ObterCategoriaComProdutos(int CategoriaId)
        {
            return await _context.Categoria
                    .Include(p => p.Produto)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == CategoriaId);
        }
    }
}
