namespace Library.Core.QueryFilters
{
    public abstract class PagedListQueryFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
