using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Services
{
    public class SearchAnalyticsService : ISearchAnalyticsService
    {
        private readonly Dictionary<string, int> _searchCounts = new Dictionary<string, int>();
        private readonly Dictionary<string, int> _resultCounts = new Dictionary<string, int>();

       
        public void TrackSearch(string query, int resultCount)
        {
            // Track number of times the query was typed
            if (_searchCounts.ContainsKey(query))
                _searchCounts[query]++;
            else
                _searchCounts[query] = 1;

            // Track total number of results returned for this query
            if (_resultCounts.ContainsKey(query))
                _resultCounts[query] += resultCount;
            else
                _resultCounts[query] = resultCount;
        }

        // Returns top N search phrases
        public Dictionary<string, int> GetTopSearches(int count)
        {
            return _searchCounts
                .OrderByDescending(s => s.Value)
                .Take(count)
                .ToDictionary(k => k.Key, v => v.Value);
        }

        // Returns top N by total results returned
        public Dictionary<string, int> GetTopResults(int count)
        {
            return _resultCounts
                .OrderByDescending(r => r.Value)
                .Take(count)
                .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}
