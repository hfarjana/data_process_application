using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{


public interface ISearchAnalyticsService
{
 void TrackSearch(string query, int resultCount);
 Dictionary<string, int> GetTopSearches(int limit);
 Dictionary<string, int> GetTopResults(int limit);


}
}