using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int i);
        Task<T> RemoveAsync(int i);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
