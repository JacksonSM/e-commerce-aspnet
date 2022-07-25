using AspStore.Domain.Entities;
using AspStore.Domain.Interfaces.Repository;
using AspStore.Infra.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspStore.Infra.Data.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity, new()
    {
        protected AspStoreDbContext _context;

        protected GenericRepository(AspStoreDbContext context)
        {
            this._context = context;
        }

        public virtual async Task Adicionar(T obj)
        {
            _context.Entry(obj).State = EntityState.Added;
        }

        public virtual async Task Atualizar(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Excluir(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
        }

        public virtual async Task ExcluirPorId(int id)
        {
            T obj = await SelecionarPorId(id);
            await Excluir(obj);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> SelecionarPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> SelecionarTodos(Expression<Func<T, bool>> quando = null)
        {
            if (quando == null)
            {
                return await this._context.Set<T>().AsNoTracking().ToListAsync();
            }
            return await this._context.Set<T>().AsNoTracking().Where(quando).ToListAsync(); 
        }
    }
}
