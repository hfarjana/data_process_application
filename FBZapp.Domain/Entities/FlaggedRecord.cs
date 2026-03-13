using System;

namespace FBZapp.Domain.Entities
{
    public class FlaggedRecord
    {
        public int Id { get; set; }
        public string ComicTitle { get; set; }
        public string FlagReason { get; set; }
        public int FlaggedByUserId { get; set; }
        public DateTime FlaggedDate { get; set; }
    }
}