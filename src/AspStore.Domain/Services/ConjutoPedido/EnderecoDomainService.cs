using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Domain.Interfaces.Repository.ConjuntoPedido;
using AspStore.Domain.Interfaces.Services.ConjutoPedido;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Services.ConjutoPedido
{
    public class EnderecoDomainService : IEnderecoDomainService 
    {

        private readonly IEnderecoRepository _repo;

        public EnderecoDomainService(IEnderecoRepository repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(Endereco obj)
        {


            await _repo.Adicionar(obj);
        }

        public async Task Atualizar(Endereco obj)
        {

            await _repo.Atualizar(obj);
        }

        public async Task Excluir(Endereco obj)
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



        public async Task<Endereco> SelecionarPorId(int id)
        {
            return await _repo.SelecionarPorId(id);
        }

        public async Task<IEnumerable<Endereco>> SelecionarTodos(Expression<Func<Endereco, bool>> quando = null)
        {
            return await _repo.SelecionarTodos(quando);
        }


    }
}
