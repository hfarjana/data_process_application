namespace FBZapp.Domain.Entities
{
    public class BookApiResult
    {
        public bool IsFound { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Authors { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public string PublishedDate { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ThumbnailUrl { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;
    }
}
