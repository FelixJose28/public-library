using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    public class BookStatusRepository : GenericRepository<BookStatus>, IBookStatusRepository
    {
        public BookStatusRepository(DBLibraryContext context) : base(context)
        {

        }
    }
}
