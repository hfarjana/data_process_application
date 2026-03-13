using System;

namespace FBZapp.Domain.Entities
{
    public class SearchResultLog
    {
        public int Id { get; set; }
        public string QueryText { get; set; }
        public string ComicTitle { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
