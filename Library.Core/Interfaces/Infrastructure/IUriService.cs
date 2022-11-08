using Library.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.Infrastructure
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(AuthorQueryFilter filters, string actionUrl);
    }
}
