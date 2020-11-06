using STN.Clientes.Domain.Contracts.Repositories;
using STN.Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STN.Clientes.Data.EF.Repositories
{
    public class RepositoryEF<T> : IRepositoryEF<T> where T : Entity
    {
        protected readonly StoreDataContext _ctx;

        public RepositoryEF(StoreDataContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            save();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            save();
        }

        public void Edit(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            save();
        }

        private void save()
        {
            _ctx.SaveChanges();
        }

        public T Get(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _ctx.Set<T>().ToList();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }
    }
}
