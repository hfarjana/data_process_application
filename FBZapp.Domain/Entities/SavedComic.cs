using System;

namespace FBZapp.Domain.Entities
{
    public class SavedComic
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ComicTitle { get; set; }
        public DateTime SavedDate { get; set; }
    }
}
