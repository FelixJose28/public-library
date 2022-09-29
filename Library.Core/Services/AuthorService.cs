using Library.Core.Models.Entities;
using Library.Core.Interfaces;
using Library.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _unitOfWork._authorReporitory.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _unitOfWork._authorReporitory.GetAllAsync();
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _unitOfWork._authorReporitory.AddAsync(author);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateAuthorAsync(Author author)
        {
            _unitOfWork._authorReporitory.Update(author);
            await _unitOfWork.CommitAsync();
        }
    }
}
