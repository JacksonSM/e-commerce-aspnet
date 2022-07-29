using AspStore.Domain.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IGenericRepository<Produto>
    {
        Task<int> GerarCodigoInterno(); 
    }
}
