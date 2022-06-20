using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task AddBookAsync(Book book);
    }
}
