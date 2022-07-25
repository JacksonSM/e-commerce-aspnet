using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services
{
    public interface ICategoriaDomainService : IGenericDomainService<Categoria>
    {
        Task<Categoria> ObterCategoriaComProdutos(int CategoriaId);
    }
}
