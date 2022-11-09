using Library.Core.Interfaces.Infrastructure;
using Library.Core.QueryFilters;
using System;

namespace Library.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        //obtiene la url de los posts
        public Uri GetPostPaginationUri(AuthorQueryFilter filters, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
