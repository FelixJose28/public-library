using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    public class BookImgRepository : GenericRepository<BookImg>, IBookImgRepository
    {
        public BookImgRepository(DBLibraryContext context) : base(context)
        {
        }
    }
}
