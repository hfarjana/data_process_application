using System;

namespace FBZapp.Domain.Entities
{
    public class SavedSearch
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string QueryText { get; set; }
        public string Genre { get; set; }
        public string SortOption { get; set; }
        public DateTime SavedDate { get; set; }
    }
}
