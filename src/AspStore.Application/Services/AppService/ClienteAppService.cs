using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using AspStore.Domain.Interfaces.Services;
using AspStore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Services.AppService
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteDomainService _service;

        public ClienteAppService(IMapper mapper, IClienteDomainService pro_service)
        {
            _mapper = mapper;
            _service = pro_service;
        }

        public async Task Adicionar(ClienteViewModel Cliente)
        {
            var pro = _mapper.Map<Cliente>(Cliente);
            await _service.Adicionar(pro);
        }

        public async Task Atualizar(ClienteViewModel Cliente)
        {
            await _service.Atualizar(_mapper.Map<Cliente>(Cliente));
        }

        public async Task Excluir(ClienteViewModel Cliente)
        {
            await _service.Excluir(_mapper.Map<Cliente>(Cliente));
        }

        public async Task ExcluirPorId(int id)
        {
            await _service.ExcluirPorId(id);
        }

        public async Task<ClienteViewModel> ObterClienteComCarrinho(int ClienteId)
        {
            return _mapper.Map<ClienteViewModel>(await _service.ObterClienteComCarrinho(ClienteId));
        }

        public async Task<ClienteViewModel> ObterClienteComListaEnderecos(int ClienteId)
        {
            return _mapper.Map<ClienteViewModel>(await _service.ObterClienteComListaEnderecos(ClienteId));
        }

        public async Task<ClienteViewModel> ObterClienteComListaPedidos(int ClienteId)
        {
            return _mapper.Map<ClienteViewModel>(await _service.ObterClienteComListaPedidos(ClienteId));
        }

        public int Save()
        {
            return _service.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _service.SaveAsync();
        }

        public async Task<ClienteViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<ClienteViewModel>(await _service.SelecionarPorId(id));
        }

        public async Task<IEnumerable<ClienteViewModel>> SelecionarTodos(Expression<Func<Cliente, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _service.SelecionarTodos(quando));
        }
    }
}
