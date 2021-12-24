using System;
using Disney.Core.QueryFilters;

namespace Disney.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetCharacterPaginationUri(CharacterQueryFilter filter, string actionUrl);
    }
}