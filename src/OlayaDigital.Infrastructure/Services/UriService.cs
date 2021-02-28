using OlayaDigital.Core.QueryFilters;
using OlayaDigital.Infrastructure.Interfaces;
using System;

namespace OlayaDigital.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostPaginationUri( PostQueryFilter filter, string actioUrl )
        {
            string baseUrl = $"{_baseUri}{actioUrl}";
            return new Uri(baseUrl);
        }

    }
}
