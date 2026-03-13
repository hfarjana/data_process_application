using System.Collections.Generic;

namespace FBZapp.Application.Interfaces
{
    public interface IAnalyticsRepository
    {
        void LogSearch(int? userId, string queryText);
        void LogSearchResults(string queryText, List<string> comicTitles);

        List<KeyValuePair<string, int>> GetTopSearchQueries();
        List<KeyValuePair<string, int>> GetTopReturnedComics();
        List<KeyValuePair<string, int>> GetComicsReturnedMoreThan100Times();
    }
}
