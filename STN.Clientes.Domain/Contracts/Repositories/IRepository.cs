using STN.Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STN.Clientes.Domain.Contracts.Repositories
{
    public interface IRepositoryEF<T> where T: Entity
    {
        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        T Get(int id);

        Task<T> GetAsync(int id);

        IEnumerable<T> Get();

        Task<IEnumerable<T>> GetAsync();

    }
}
