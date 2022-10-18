using Library.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(AuthorQueryFilter filters, string actionUrl);
    }
}
