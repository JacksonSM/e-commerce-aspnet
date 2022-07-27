using AspStore.Application.ViewModels;
using AspStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService
{
    public interface IProdutoAppService
    {
        Task Adicionar(ProdutoViewModel produto);
        Task Atualizar(ProdutoViewModel produto);
        Task Excluir(ProdutoViewModel produto);

        Task<IEnumerable<ProdutoViewModel>> SelecionarTodos(Expression<Func<Produto, bool>> quando = null);
        Task<ProdutoViewModel> SelecionarPorId(int id);
        Task ExcluirPorId(int id);


        Task<int> SaveAsync();
        int Save();
    }
}
