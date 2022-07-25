using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Domain.Interfaces.Repository.ConjuntoPedido;
using AspStore.Domain.Interfaces.Services.ConjutoPedido;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Services.ConjutoPedido
{
    public class ProdutoPedidoDomainService : IProdutoPedidoDomainService
    {
        private readonly IProdutoPedidoRepository _repo;

        public ProdutoPedidoDomainService(IProdutoPedidoRepository repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(ProdutoPedido obj)
        {


            await _repo.Adicionar(obj);
        }

        public async Task Atualizar(ProdutoPedido obj)
        {

            await _repo.Atualizar(obj);
        }

        public async Task Excluir(ProdutoPedido obj)
        {


            await _repo.Excluir(obj);
        }

        public async Task ExcluirPorId(int id)
        {

            await _repo.ExcluirPorId(id);
        }

        public int Save()
        {
            return _repo.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _repo.SaveAsync();
        }



        public async Task<ProdutoPedido> SelecionarPorId(int id)
        {
            return await _repo.SelecionarPorId(id);
        }

        public async Task<IEnumerable<ProdutoPedido>> SelecionarTodos(Expression<Func<ProdutoPedido, bool>> quando = null)
        {
            return await _repo.SelecionarTodos(quando);
        }

    }
}
