using Library.Core.Models.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DBLibraryContext context) : base(context)
        {
        }
    }
}
