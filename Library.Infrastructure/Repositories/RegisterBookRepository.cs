using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    public class RegisterBookRepository : GenericRepository<RegisterBook>, IRegisterBookRepository
    {
        public RegisterBookRepository(DBLibraryContext context) : base(context)
        {

        }
    }
}
