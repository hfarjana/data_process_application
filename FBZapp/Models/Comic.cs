using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Models
{
    using CsvHelper.Configuration.Attributes;

    public class Comic
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        
        public List<ComicVariant> Variants { get; set; } = new List<ComicVariant>();

        // ✅ Derived year (earliest publication year)
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

        // ✅ Combined ISBNs
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


