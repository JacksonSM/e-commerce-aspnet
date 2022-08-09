using AspStore.Domain.Interfaces.Repository;
using AspStore.Entities;
using AspStore.Infra.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AspStoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Cliente> ObterClienteComCarrinho(string CPF)
        {
            return await _context.Cliente
                    .Include(p => p.Carrinho)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.CPF.NumeroCPF == CPF);
        }

        public async Task<Cliente> ObterClienteComListaEnderecos(int ClienteId)
        {
            return await _context.Cliente
                    .Include(p => p.Endereco)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == ClienteId);
        }

        public async Task<Cliente> ObterClienteComListaPedidos(int ClienteId)
        {
            return await _context.Cliente
                    .Include(p => p.Pedido)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == ClienteId);
        }

     
    }
}
