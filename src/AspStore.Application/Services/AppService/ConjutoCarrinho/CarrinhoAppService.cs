using AspStore.Application.Interfaces.AppService.ConjutoCarrinho;
using AspStore.Application.ViewModels;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AspStore.Domain.Interfaces.Services.ConjutoCarrinho;
using AspStore.Entities;
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
      
        public async Task<CarrinhoViewModel> ObterCarrinhoComProduto(string CPF)
        {
            var carrinho = await _service.ObterCarrinhoComProduto(CPF);
            var produtosVM = _mapper.Map<List<ProdutoCarrinhoViewModel>>(carrinho.ProdutoCarrinho);
            var carrinhoVM = _mapper.Map<CarrinhoViewModel>(carrinho);
            carrinhoVM.ProdutoCarrinhoModelView = produtosVM;

            return carrinhoVM;
        }

        public async Task SalvarProdutoNoCarrinho(ClienteViewModel clienteVM, ProdutoCarrinhoViewModel produtoCarrinhoVM)
        {
            var cliente = _mapper.Map<Cliente>(clienteVM);
            var produtoCarrinho = _mapper.Map<ProdutoCarrinho>(produtoCarrinhoVM);
            await _service.SalvarProdutoNoCarrinho(cliente, produtoCarrinho);
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
