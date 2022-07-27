using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Application.Interfaces.AppService
{
    public interface IGenericAppService<TViewModel, TEntity>
    {
        Task Adicionar(TViewModel objVM);
        Task Atualizar(TViewModel objVM);
        Task Excluir(TViewModel objVM);

        Task<IEnumerable<TViewModel>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
        Task<TViewModel> SelecionarPorId(int id);
        Task ExcluirPorId(int id);


        Task<int> SaveAsync();
        int Save();
    }
}
