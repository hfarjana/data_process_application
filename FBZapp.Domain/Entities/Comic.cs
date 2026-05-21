using System.Collections.Generic;
using System.Linq;

namespace FBZapp.Domain.Entities
{
    public class Comic
    {
        // Local CSV data
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Languages { get; set; } = string.Empty;

        public List<ComicVariant> Variants { get; set; } = new List<ComicVariant>();

        // API enriched data
        public string ApiTitle { get; set; } = string.Empty;

        public string ApiAuthors { get; set; } = string.Empty;

        public string ApiPublisher { get; set; } = string.Empty;

        public string ApiPublishedDate { get; set; } = string.Empty;

        public string ApiDescription { get; set; } = string.Empty;

        public string ApiThumbnailUrl { get; set; } = string.Empty;

        public string ApiISBN { get; set; } = string.Empty;

        public string ApiSource { get; set; } = string.Empty;

        public bool IsApiEnriched { get; set; }

        // Calculated year from local CSV variants
        public int Year
        {
            get
            {
                return Variants
                    .Select(v => v.GetNumericYear())
                    .Where(y => y > 0)
                    .DefaultIfEmpty(0)
                    .Min();
            }
        }

        // Calculated ISBN from local CSV variants
        public string ISBN
        {
            get
            {
                return string.Join("; ",
                    Variants
                        .Select(v => string.IsNullOrWhiteSpace(v.ISBN) ? "missing" : v.ISBN)
                        .Distinct());
            }
        }

        // Display values use API data first, then fall back to CSV data

        public string DisplayTitle
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ApiTitle) ? ApiTitle : Title;
            }
        }

        public string DisplayAuthor
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ApiAuthors) ? ApiAuthors : Author;
            }
        }

        public string DisplayPublisher
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ApiPublisher) ? ApiPublisher : Publisher;
            }
        }

        public string DisplayPublishedDate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ApiPublishedDate))
                {
                    return ApiPublishedDate;
                }

                return Year > 0 ? Year.ToString() : "Unknown date";
            }
        }

        public string DisplayDescription
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ApiDescription) ? ApiDescription : Description;
            }
        }

        public string DisplayISBN
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ApiISBN) ? ApiISBN : ISBN;
            }
        }

        public string DisplayCoverImageUrl
        {
            get
            {
                return ApiThumbnailUrl;
            }
        }

        public string DisplayApiStatus
        {
            get
            {
                return IsApiEnriched ? "API data found" : "No API data found";
            }
        }
    }
}


