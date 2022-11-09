using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = default);
        Task<T> GetByIdAsync(int i);
        Task<T> RemoveAsync(int i);
        Task<T> AddAsync(T entity);
        T Update(T entity);
    }
}
