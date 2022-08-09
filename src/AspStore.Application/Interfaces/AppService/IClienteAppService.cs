using AspStore.Application.ViewModels;
using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService
{
    public interface IClienteAppService : IGenericAppService<ClienteViewModel, Cliente>
    {
        Task<ClienteViewModel> ObterClienteComCarrinho(string CPF);
        Task<ClienteViewModel> ObterClienteComListaEnderecos(int ClienteId);
        Task<ClienteViewModel> ObterClienteComListaPedidos(int ClienteId);
    }
}
