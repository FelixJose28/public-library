using Library.Core.QueryFilters;
using System;

namespace Library.Core.Interfaces.Infrastructure
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(AuthorQueryFilter filters, string actionUrl);
    }
}
