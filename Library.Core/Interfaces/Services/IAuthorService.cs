using Library.Core.CustomEntities.Pagination;
using Library.Core.Entities;
using Library.Core.QueryFilters;
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
