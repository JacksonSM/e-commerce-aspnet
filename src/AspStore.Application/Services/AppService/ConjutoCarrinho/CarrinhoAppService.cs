using AspStore.Application.Interfaces.AppService.ConjutoCarrinho;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Interfaces.Services.ConjutoCarrinho;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Services.ConjutoCarrinho
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICarrinhoDomainService _service;

        public CarrinhoAppService(IMapper mapper, ICarrinhoDomainService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task Adicionar(CarrinhoViewModel Carrinho)
        {
            var pro = _mapper.Map<Carrinho>(Carrinho);
            await _service.Adicionar(pro);
        }

        public async Task Atualizar(CarrinhoViewModel Carrinho)
        {
            await _service.Atualizar(_mapper.Map<Carrinho>(Carrinho));
        }

        public async Task Excluir(CarrinhoViewModel Carrinho)
        {
            await _service.Excluir(_mapper.Map<Carrinho>(Carrinho));
        }

        public async Task ExcluirPorId(int id)
        {
            await _service.ExcluirPorId(id);
        }

        public async Task<CarrinhoViewModel> ObterCarrinhoComProduto(int ClienteId)
        {
            return _mapper.Map<CarrinhoViewModel>(await _service.ObterCarrinhoComProduto(ClienteId));
        }

        public int Save()
        {
            return _service.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _service.SaveAsync();
        }

        public async Task<CarrinhoViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<CarrinhoViewModel>(await _service.SelecionarPorId(id));
        }

        public async Task<IEnumerable<CarrinhoViewModel>> SelecionarTodos(Expression<Func<Carrinho, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<CarrinhoViewModel>>(await _service.SelecionarTodos(quando));
        }
    }
}
