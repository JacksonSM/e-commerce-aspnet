using AspStore.Entities;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<Cliente> ObterClienteComCarrinho(int ClienteId);
        Task<Cliente> ObterClienteComListaEnderecos(int ClienteId);
        Task<Cliente> ObterClienteComListaPedidos(int ClienteId);

    }
}
