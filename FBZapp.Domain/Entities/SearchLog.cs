using System;

namespace FBZapp.Domain.Entities
{
    public class SearchLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string QueryText { get; set; }
        public DateTime SearchDate { get; set; }
    }
}