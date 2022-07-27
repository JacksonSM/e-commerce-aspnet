using AspStore.Application.Interfaces.AppService.ConjutoCarrinho;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Domain.Interfaces.Services.ConjutoCarrinho;
using AspStore.Domain.Entities.ConjuntoCarrinho;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace AspStore.Application.Services.ConjutoProdutoCarrinho
{
    public class ProdutoCarrinhoAppService : IProdutoCarrinhoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoCarrinhoDomainService _service;

        public ProdutoCarrinhoAppService(IMapper mapper, IProdutoCarrinhoDomainService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task Adicionar(ProdutoCarrinhoViewModel ProdutoCarrinhoVM)
        {
            var pro = _mapper.Map<ProdutoCarrinho>(ProdutoCarrinhoVM);
            await _service.Adicionar(pro);
        }

        public async Task Atualizar(ProdutoCarrinhoViewModel ProdutoCarrinhoVM)
        {
            await _service.Atualizar(_mapper.Map<ProdutoCarrinho>(ProdutoCarrinhoVM));
        }

        public async Task Excluir(ProdutoCarrinhoViewModel ProdutoCarrinhoVM)
        {
            await _service.Excluir(_mapper.Map<ProdutoCarrinho>(ProdutoCarrinhoVM));
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

        public async Task<ProdutoCarrinhoViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<ProdutoCarrinhoViewModel>(await _service.SelecionarPorId(id));
        }

        public async Task<IEnumerable<ProdutoCarrinhoViewModel>> SelecionarTodos(Expression<Func<ProdutoCarrinho, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<ProdutoCarrinhoViewModel>>(await _service.SelecionarTodos(quando));
        }
    }
}
