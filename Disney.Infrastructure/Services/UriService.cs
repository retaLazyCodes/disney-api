using System;
using Disney.Core.QueryFilters;
using Disney.Infrastructure.Interfaces;

namespace Disney.Infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        
        public Uri GetCharacterPaginationUri(CharacterQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
        
    }
}