using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Interfaces.Repository.ConjuntoCarrinho;
using AspStore.Domain.Interfaces.Services.ConjutoCarrinho;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Services.ConjutoCarrinho
{
    public class ProdutoCarrinhoDomainService : IProdutoCarrinhoDomainService
    {
        private readonly IProdutoCarrinhoRepository _repo;

        public ProdutoCarrinhoDomainService(IProdutoCarrinhoRepository repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(ProdutoCarrinho obj)
        {


            await _repo.Adicionar(obj);
        }

        public async Task Atualizar(ProdutoCarrinho obj)
        {

            await _repo.Atualizar(obj);
        }

        public async Task Excluir(ProdutoCarrinho obj)
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



        public async Task<ProdutoCarrinho> SelecionarPorId(int id)
        {
            return await _repo.SelecionarPorId(id);
        }

        public async Task<IEnumerable<ProdutoCarrinho>> SelecionarTodos(Expression<Func<ProdutoCarrinho, bool>> quando = null)
        {
            return await _repo.SelecionarTodos(quando);
        }

    }
}
