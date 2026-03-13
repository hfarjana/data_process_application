using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface ISearchService
    {
        List<Comic> GlobalSearch(string query);
        List<Comic> FilterByGenre(List<Comic> comics, string genre);
        List<Comic> ApplySorting(List<Comic> comics, string sortOption);
        List<Comic> GroupComics(List<Comic> comics, string groupBy);
        List<Comic> AdvancedSearch(string author, string genre, int? year, string language, string nameType);
    }
}
