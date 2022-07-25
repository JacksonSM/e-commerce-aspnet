using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspStore.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> SelecionarTodos(Expression<Func<T, bool>> quando = null);
        Task<T> SelecionarPorId(int id);
        Task Adicionar(T obj);
        Task Atualizar(T obj);
        Task Excluir(T obj);
        Task ExcluirPorId(int id);

        Task<int> SaveAsync();
        int Save();
    }
}
