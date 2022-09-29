using Library.Core.Interfaces;
using Library.Core.Entities;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class RegisterBookRepository : GenericRepository<RegisterBook>, IRegisterBookRepository
    {
        public RegisterBookRepository(DBLibraryContext context) : base(context)
        {

        }
    }
}
