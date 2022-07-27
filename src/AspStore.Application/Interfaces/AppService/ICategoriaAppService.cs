using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Domain.Entities;
using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService
{
    public interface ICategoriaAppService : IGenericAppService<CategoriaViewModel, Categoria>
    {
        Task<CategoriaViewModel> ObterCategoriaComProdutos(int CategoriaId);
    }
}
