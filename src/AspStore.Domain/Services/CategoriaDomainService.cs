using AspStore.Domain.Interfaces.Repository;
using AspStore.Domain.Interfaces.Services;
using AspStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Services
{
    public class CategoriaDomainService : ICategoriaDomainService
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaDomainService(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(Categoria obj)
        {


            await _repo.Adicionar(obj);
        }

        public async Task Atualizar(Categoria obj)
        {

            await _repo.Atualizar(obj);
        }

        public async Task Excluir(Categoria obj)
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



        public async Task<Categoria> SelecionarPorId(int id)
        {
            return await _repo.SelecionarPorId(id);
        }

        public async Task<IEnumerable<Categoria>> SelecionarTodos(Expression<Func<Categoria, bool>> quando = null)
        {
            return await _repo.SelecionarTodos(quando);
        }

        public async Task<Categoria> ObterCategoriaComProdutos(int CategoriaId)
        {
            return await _repo.ObterCategoriaComProdutos(CategoriaId);
        }
    }
}
