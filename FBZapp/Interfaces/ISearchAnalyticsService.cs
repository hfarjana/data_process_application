using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Interfaces
{


public interface ISearchAnalyticsService
{
 void TrackSearch(string query, int resultCount);
 Dictionary<string, int> GetTopSearches(int limit);
 Dictionary<string, int> GetTopResults(int limit);


}
}