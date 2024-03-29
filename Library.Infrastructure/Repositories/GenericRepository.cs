﻿using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
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

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = default)
        {
            IQueryable<T> query = null;
            if (filter is null)
            {
                query = _dbSetEntities.AsNoTracking();
            }
            else
            {
                query = _dbSetEntities.AsNoTracking().Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSetEntities.FindAsync(id);
            if (entity is not null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<T> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            var entityEntry = _dbSetEntities.Remove(entity);
            return entityEntry.Entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
