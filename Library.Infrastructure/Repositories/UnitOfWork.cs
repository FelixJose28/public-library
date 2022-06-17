﻿using Library.Core.Interfaces;
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
        public IAlertRepository _alertRepository { get; }
        public IAuthorReporitory _authorReporitory { get; }
        public IBookRepository _bookRepository { get; }
        public IUserRepository _userRepository { get; }


        public UnitOfWork(
            DBLibraryContext context,
            IAlertRepository alertRepository, 
            IAuthorReporitory authorReporitory, 
            IBookRepository bookRepository, 
            IUserRepository userRepository)
        {
            _context = context;
            _alertRepository = alertRepository;
            _authorReporitory = authorReporitory;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
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
