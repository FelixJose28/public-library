using Library.Core.CustomEntities.Pagination;
using Library.Core.Entities;
using Library.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<PagedList<Author>> GetAuthorsAsync(AuthorQueryFilter filters);
        Task<Author> GetAuthorAsync(int id);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task RemoveAuthorAsync(int authorId);
    }
}
