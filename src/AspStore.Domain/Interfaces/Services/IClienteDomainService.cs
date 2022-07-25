using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Services
{
    public interface IClienteDomainService : IGenericDomainService<Cliente>
    {
        Task<Cliente> ObterClienteComCarrinho(int ClienteId);
        Task<Cliente> ObterClienteComListaEnderecos(int ClienteId);
        Task<Cliente> ObterClienteComListaPedidos(int ClienteId);
    }
}
