using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    public class AlertRepository : GenericRepository<Alert>, IAlertRepository
    {
        public AlertRepository(DBLibraryContext context) : base(context)
        {
        }
    }
}
