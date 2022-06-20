using Library.Core.Entities;
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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> GetBookAsync(int id)
        {
            return await _unitOfWork._bookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _unitOfWork._bookRepository.GetAllAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            await _unitOfWork._bookRepository.AddAsync(book);
            await _unitOfWork.CommitAsync();
        }
    }
}
