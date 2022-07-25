using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<Categoria> ObterCategoriaComProdutos(int CategoriaId);
    }
}
