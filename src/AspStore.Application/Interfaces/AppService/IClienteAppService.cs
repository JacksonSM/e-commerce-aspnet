using AspStore.Application.ViewModels;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService
{
    public interface IClienteAppService<TEntity> : IGenericAppService<ClienteViewModel, TEntity>
    {
        Task<ClienteViewModel> ObterClienteComCarrinho(int ClienteId);
        Task<ClienteViewModel> ObterClienteComListaEnderecos(int ClienteId);
        Task<ClienteViewModel> ObterClienteComListaPedidos(int ClienteId);
    }
}
