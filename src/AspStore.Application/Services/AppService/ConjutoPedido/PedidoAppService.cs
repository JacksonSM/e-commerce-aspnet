using AspStore.Application.Interfaces.AppService.ConjutoPedido;
using AspStore.Application.ViewModels.ConjutoPedido;
using AspStore.Domain.Interfaces.Services.ConjutoPedido;
using AspStore.Domain.Entities.ConjuntoPedido;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace AspStore.Application.Services.AppService.ConjutoPedido
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IMapper _mapper;
        private readonly IPedidoDomainService _service;

        public PedidoAppService(IMapper mapper, IPedidoDomainService proService)
        {
            _mapper = mapper;
            _service = proService;
        }

        public async Task Adicionar(PedidoViewModel Pedido)
        {
            var pro = _mapper.Map<Pedido>(Pedido);
            await _service.Adicionar(pro);
        }

        public async Task Atualizar(PedidoViewModel Pedido)
        {
            await _service.Atualizar(_mapper.Map<Pedido>(Pedido));
        }

        public async Task Excluir(PedidoViewModel Pedido)
        {
            await _service.Excluir(_mapper.Map<Pedido>(Pedido));
        }

        public async Task ExcluirPorId(int id)
        {
            await _service.ExcluirPorId(id);
        }

        public async Task<PedidoViewModel> ObterPedidoComProdutos(int PedidoId)
        {
            return _mapper.Map<PedidoViewModel>(await _service.ObterPedidoComProdutos(PedidoId));
        }

        public int Save()
        {
            return _service.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _service.SaveAsync();
        }

        public async Task<PedidoViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<PedidoViewModel>(await _service.SelecionarPorId(id));
        }

        public async Task<IEnumerable<PedidoViewModel>> SelecionarTodos(Expression<Func<Pedido, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(await _service.SelecionarTodos(quando));
        }
    }
}
