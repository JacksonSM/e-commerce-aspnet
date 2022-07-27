using AspStore.Application.ViewModels;
using AspStore.Domain.Entities;

namespace AspStore.Application.Interfaces.AppService
{
    public interface IProdutoAppService : IGenericAppService<ProdutoViewModel,Produto>
    {
    }
}
