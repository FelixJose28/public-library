using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DBLibraryContext _context;
        public DbSet<T> _dbSetEntities;
        public GenericRepository(DBLibraryContext context)
        {
            _context = context;
            _dbSetEntities = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            var entityEntry = await _dbSetEntities.AddAsync(entity);
            return entityEntry.Entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSetEntities.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSetEntities.FindAsync(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            var entityEntry = _dbSetEntities.Remove(entity);
            return entityEntry.Entity;
        }

        public Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }
    }
}
