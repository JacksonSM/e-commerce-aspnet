using AspStore.Domain.Interfaces.Repository;
using AspStore.Domain.Interfaces.Services;
using AspStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _repo;

        public ClienteDomainService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task Adicionar(Cliente obj)
        {


            await _repo.Adicionar(obj);
        }

        public async Task Atualizar(Cliente obj)
        {

            await _repo.Atualizar(obj);
        }

        public async Task Excluir(Cliente obj)
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

        public async Task<Cliente> SelecionarPorId(int id)
        {
            return await _repo.SelecionarPorId(id);
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodos(Expression<Func<Cliente, bool>> quando = null)
        {

            return await _repo.SelecionarTodos(quando);
        }



        public async Task<Cliente> ObterClienteComCarrinho(string CPF)
        {
            return await _repo.ObterClienteComCarrinho(CPF);
        }

        public async Task<Cliente> ObterClienteComListaEnderecos(int ClienteId)
        {
            return await _repo.ObterClienteComListaEnderecos(ClienteId);
        }

        public async Task<Cliente> ObterClienteComListaPedidos(int ClienteId)
        {
            return await _repo.ObterClienteComListaPedidos(ClienteId);
        }
    }
}
