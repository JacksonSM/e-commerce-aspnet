using AspStore.Application.Interfaces.AppService.ConjutoPedido;
using AspStore.Application.ViewModels.ConjutoPedido;
using AspStore.Domain.Entities.ConjuntoPedido;
using AspStore.Domain.Interfaces.Services.ConjutoPedido;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Services.AppService.ConjutoPedido
{
    public class ProdutoPedidoAppService : IProdutoPedidoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoPedidoDomainService _service;

        public ProdutoPedidoAppService(IMapper mapper, IProdutoPedidoDomainService proService)
        {
            _mapper = mapper;
            _service = proService;
        }

        public async Task Adicionar(ProdutoPedidoViewModel ProdutoPedido)
        {
            var pro = _mapper.Map<ProdutoPedido>(ProdutoPedido);
            await _service.Adicionar(pro);
        }

        public async Task Atualizar(ProdutoPedidoViewModel ProdutoPedido)
        {
            await _service.Atualizar(_mapper.Map<ProdutoPedido>(ProdutoPedido));
        }

        public async Task Excluir(ProdutoPedidoViewModel ProdutoPedido)
        {
            await _service.Excluir(_mapper.Map<ProdutoPedido>(ProdutoPedido));
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

        public async Task<ProdutoPedidoViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<ProdutoPedidoViewModel>(await _service.SelecionarPorId(id));
        }

        public async Task<IEnumerable<ProdutoPedidoViewModel>> SelecionarTodos(Expression<Func<ProdutoPedido, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<ProdutoPedidoViewModel>>(await _service.SelecionarTodos(quando));
        }
    }
}
