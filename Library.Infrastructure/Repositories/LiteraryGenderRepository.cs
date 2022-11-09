using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    public class LiteraryGenderRepository : GenericRepository<LiteraryGender>, ILiteraryGenderRepository
    {
        public LiteraryGenderRepository(DBLibraryContext context) : base(context)
        {

        }
    }
}
