using AspStore.Domain.Entities;
using AspStore.Domain.Interfaces.Repository;
using AspStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {

        private readonly IProdutoRepository _repo;

        public ProdutoDomainService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(Produto obj)
        {


             await _repo.Adicionar(obj);
        }

        public async Task Atualizar(Produto obj)
        {

            await _repo.Atualizar(obj);
        }

        public async Task Excluir(Produto obj)
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

        public async Task<Produto> SelecionarPorId(int id)
        {
            return await _repo.SelecionarPorId(id);
        }

        public async Task<IEnumerable<Produto>> SelecionarTodos(Expression<Func<Produto, bool>> quando = null)
        {

            return await _repo.SelecionarTodos(quando);
        }
    }
}
