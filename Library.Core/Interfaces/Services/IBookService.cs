using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Task<Book> GetBookAsync(int id);
    }
}
