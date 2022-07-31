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
            await _repo.SaveAsync();
        }

        public async Task Atualizar(Produto obj)
        {

            await _repo.Atualizar(obj);
            await _repo.SaveAsync();
        }

        public async Task Excluir(Produto obj)
        {


            await _repo.Excluir(obj);
            await _repo.SaveAsync();
        }

        public async Task ExcluirPorId(int id)
        {

            await _repo.ExcluirPorId(id);
            await _repo.SaveAsync();
        }

        public Task<int> GerarCodigoInterno()
        {
            return _repo.GerarCodigoInterno();
        }

        public async Task<Produto> ObterProdutoComCategoria(int produtoId)
        {
            return await _repo.ObterProdutoComCategoria(produtoId);
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

        public async Task<IEnumerable<Produto>> TodosProdutoComCategoria()
        {
            return await _repo.TodosProdutoComCategoria();
        }
    }
}
