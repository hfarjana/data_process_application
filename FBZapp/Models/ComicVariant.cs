using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Models
{
 public class ComicVariant
 {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }

        // raw year string exactly as in CSV
        public string RawYear { get; set; }

        public string ISBN { get; set; }

      

        // Safe helper to extract a numeric year from RawYear
        public int GetNumericYear()
        {
            if (string.IsNullOrWhiteSpace(RawYear))
                return 0;

            var match = System.Text.RegularExpressions.Regex.Match(RawYear, @"\b(19|20)\d{2}\b");
            return match.Success ? int.Parse(match.Value) : 0;
        }
    }


}
