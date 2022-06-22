using Library.Core.Models.Entities;
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
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task AddAuthorAsync(Author author);
    }
}
