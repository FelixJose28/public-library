using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBLibraryContext _context;
        public IBookRepository _bookRepository { get; }
        
        public UnitOfWork(
            DBLibraryContext context,
            IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
