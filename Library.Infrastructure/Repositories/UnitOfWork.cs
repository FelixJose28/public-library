﻿using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBLibraryContext _context;
        public IAlertRepository _alertRepository { get; }
        public IAuthorRepository _authorReporitory { get; }
        public IBookRepository _bookRepository { get; }
        public IBookImgRepository _bookImgRepository { get; }
        public IUserRepository _userRepository { get; }
        public ILoginRepository _loginRepository { get; }


        public UnitOfWork(
            DBLibraryContext context,
            IAlertRepository alertRepository,
            IAuthorRepository authorReporitory,
            IBookRepository bookRepository,
            IBookImgRepository bookImgRepository,
            IUserRepository userRepository,
            ILoginRepository loginRepository)
        {
            _context = context;
            _alertRepository = alertRepository;
            _authorReporitory = authorReporitory;
            _bookRepository = bookRepository;
            _bookImgRepository = bookImgRepository;
            _userRepository = userRepository;
            _loginRepository = loginRepository;
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
            if (_context is not null)
            {
                _context.Dispose();
            }
        }
    }
}
