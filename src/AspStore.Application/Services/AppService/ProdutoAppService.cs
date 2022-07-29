using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using AspStore.Domain.Entities;
using AspStore.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoDomainService _proService;

        public ProdutoAppService(IMapper mapper, IProdutoDomainService proService)
        {
            _mapper = mapper;
            _proService = proService;
        }

        public async Task Adicionar(ProdutoViewModel produto)
        {
            var pro = _mapper.Map<Produto>(produto);
           await _proService.Adicionar(pro);
        }

        public async Task Atualizar(ProdutoViewModel produto)
        {
           await _proService.Atualizar(_mapper.Map<Produto>(produto));
        }

        public async Task Excluir(ProdutoViewModel produto)
        {
           await _proService.Excluir(_mapper.Map<Produto>(produto));
        }

        public async Task ExcluirPorId(int id)
        {
             await _proService.ExcluirPorId(id);
        }

        public Task<int> GerarCodigoInterno()
        {
            return _proService.GerarCodigoInterno();
        }

        public int Save()
        {
            return _proService.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _proService.SaveAsync();
        }

        public async Task<ProdutoViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _proService.SelecionarPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> SelecionarTodos(Expression<Func<Produto, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _proService.SelecionarTodos(quando));
        }

        public async Task<IEnumerable<ProdutoViewModel>> TodosProdutoComCategoria()
        {

            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _proService.TodosProdutoComCategoria());
        }
    }
}
