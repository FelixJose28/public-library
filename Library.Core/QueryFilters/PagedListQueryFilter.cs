using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.QueryFilters
{
    public abstract class PagedListQueryFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
