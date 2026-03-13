using FBZapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Interfaces
{



    public interface ISearchService
    {
        List<Comic> GlobalSearch(string query);
        List<Comic> AdvancedSearch(string author, string publisher, int yearFrom, int yearTo);
        List<Comic> ApplySorting(List<Comic> comics, string sortOption);
        List<IGrouping<string, Comic>> GroupComics(List<Comic> comics, string groupOption);
        List<Comic> FilterByGenre(List<Comic> comics, string genre);

    }


}
