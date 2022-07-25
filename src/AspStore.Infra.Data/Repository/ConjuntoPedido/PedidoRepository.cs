using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Domain.Interfaces.Repository.ConjuntoPedido;
using AspStore.Infra.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.Repository.ConjuntoPedido
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AspStoreDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Pedido> ObterPedidoComProdutos(int PedidoId)
        {
            return await _context.Pedido
                .Include(p => p.ProdutoPedido)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == PedidoId);
        }
    }
}
