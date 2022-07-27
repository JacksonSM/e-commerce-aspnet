using AspStore.Application.Interfaces.AppService;
using AspStore.Application.ViewModels;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Domain.Interfaces.Services;
using AspStore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaDomainService _service;
        private readonly IMapper _mapper;
        public CategoriaAppService(ICategoriaDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Adicionar(CategoriaViewModel categoriaVM)
        {

           await  _service.Adicionar(_mapper.Map<Categoria>(categoriaVM));
        }

        public async Task Atualizar(CategoriaViewModel categoriaVM)
        {
            await _service.Atualizar(_mapper.Map<Categoria>(categoriaVM));
        }

        public async Task Excluir(CategoriaViewModel categoriaVM)
        {
            await _service.Excluir(_mapper.Map<Categoria>(categoriaVM));
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
            return await  _service.SaveAsync();
        }

        public async Task<ProdutoViewModel> SelecionarPorId(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _service.SelecionarPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> SelecionarTodos(Expression<Func<Categoria, bool>> quando = null)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _service.SelecionarTodos(quando));
        }
    }
}
