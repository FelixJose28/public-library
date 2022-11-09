using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    public class TelephoneRepository : GenericRepository<Telephone>, ITelephoneRepository
    {
        public TelephoneRepository(DBLibraryContext context) : base(context)
        {
        }
    }
}
