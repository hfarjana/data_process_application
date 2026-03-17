using System.Collections.Generic;
using System.Linq;

namespace FBZapp.Domain.Entities
{
    public class Comic
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;

        public List<ComicVariant> Variants { get; set; } = new List<ComicVariant>();

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
    }
}


