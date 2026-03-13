using System.Text.RegularExpressions;

namespace FBZapp.Domain.Entities
{
    public class ComicVariant
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string Notes { get; set; }
        public string RawYear { get; set; }
        public string ISBN { get; set; }
        public string Languages { get; set; }
        public string Description { get; set; }

        public int GetNumericYear()
        {
            if (string.IsNullOrWhiteSpace(RawYear))
                return 0;

            var match = Regex.Match(RawYear, @"\b(19|20)\d{2}\b");
            return match.Success ? int.Parse(match.Value) : 0;
        }
    }
}