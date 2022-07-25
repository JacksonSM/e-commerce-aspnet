using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Domain.Interfaces.Repository.ConjuntoPedido;
using AspStore.Domain.Interfaces.Services;
using AspStore.Domain.Interfaces.Services.ConjutoPedido;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Services.ConjutoPedido
{
    public class PedidoDomainService : IPedidoDomainService
    {
        private readonly IPedidoRepository _repo;

        public PedidoDomainService(IPedidoRepository repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(Pedido obj)
        {


            await _repo.Adicionar(obj);
        }

        public async Task Atualizar(Pedido obj)
        {

            await _repo.Atualizar(obj);
        }

        public async Task Excluir(Pedido obj)
        {


            await _repo.Excluir(obj);
        }

        public async Task ExcluirPorId(int id)
        {

            await _repo.ExcluirPorId(id);
        }

        public async Task<Pedido> ObterPedidoComProdutos(int PedidoId)
        {
            return await _repo.ObterPedidoComProdutos(PedidoId);
        }

        public int Save()
        {
            return _repo.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _repo.SaveAsync();
        }



        public async Task<Pedido> SelecionarPorId(int id)
        {
            return await _repo.SelecionarPorId(id);
        }

        public async Task<IEnumerable<Pedido>> SelecionarTodos(Expression<Func<Pedido, bool>> quando = null)
        {
            return await _repo.SelecionarTodos(quando);
        }
    }
}
