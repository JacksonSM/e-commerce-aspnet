using AspStore.Application.Interfaces.AppService.ConjutoPedido;
using AspStore.Application.ViewModels.ConjutoPedido;
using AspStore.Domain.Interfaces.Services.ConjutoPedido;
using AspStore.Domain.Entities.ConjuntoPedido;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace AspStore.Application.Services.AppService.ConjutoPedido
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoDomainService _service;

        public EnderecoAppService(IMapper mapper, IEnderecoDomainService proService)
        {
            _mapper = mapper;
            _service = proService;
        }

        public async Task Adicionar(EnderecoViewModel Endereco)
        {
            var pro = _mapper.Map<Endereco>(Endereco);
            await _service.Adicionar(pro);
        }

        public async Task Atualizar(EnderecoViewModel Endereco)
        {
            await _service.Atualizar(_mapper.Map<Endereco>(Endereco));
        }

        public async Task Excluir(EnderecoViewModel Endereco)
        {
            await _service.Excluir(_mapper.Map<Endereco>(Endereco));
        }

        public async Task ExcluirPorId(int id)
        {
            await _service.ExcluirPorId(id);
        }

        public int Save()
        {
            return _service.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _service.SaveAsync();
        }

        public async Task<EnderecoViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<EnderecoViewModel>(await _service.SelecionarPorId(id));
        }

        public async Task<IEnumerable<EnderecoViewModel>> SelecionarTodos(Expression<Func<Endereco, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<EnderecoViewModel>>(await _service.SelecionarTodos(quando));
        }
    }
}
