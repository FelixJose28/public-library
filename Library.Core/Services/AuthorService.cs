using Library.Core.CustomEntities.Pagination;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Core.Interfaces.Services;
using Library.Core.QueryFilters;
using Microsoft.Extensions.Options;
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
        private readonly PaginationOptions _paginationOptions;

        public AuthorService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
        }
        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _unitOfWork._authorReporitory.GetByIdAsync(id);
        }

        public async Task<PagedList<Author>> GetAuthorsAsync(AuthorQueryFilter filters)
        {
            var authors = await _unitOfWork._authorReporitory.GetAllAsync();
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber: filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            var authorsPaged = PagedList<Author>.Create(authors,filters.PageNumber,filters.PageSize);
            return authorsPaged;
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

        public async Task RemoveAuthorAsync(int authorId)
        {
            await _unitOfWork._authorReporitory.RemoveAsync(authorId);
            await _unitOfWork.CommitAsync();
        }
    }
}
