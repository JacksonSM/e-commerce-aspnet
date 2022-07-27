using AspStore.Application.ViewModels;
using AspStore.Application.ViewModels.ConjutoCarrinho;
using AspStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService
{
    public interface ICategoriaAppService
    {
        Task Adicionar(CategoriaViewModel categoriaVM);
        Task Atualizar(CategoriaViewModel categoriaVM);
        Task Excluir(CategoriaViewModel categoriaVM);

        Task<IEnumerable<ProdutoViewModel>> SelecionarTodos(Expression<Func<Categoria, bool>> quando = null);
        Task<ProdutoViewModel> SelecionarPorId(int id);
        Task ExcluirPorId(int id);


        Task<int> SaveAsync();
        int Save();
    }
}
