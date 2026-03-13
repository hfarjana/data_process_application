using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FBZapp.Infrastructure.Helpers
{
    public static class SpecialCharacterCleaner
    {
        public static string CleanTitle(string input)
        {
            return CleanGeneric(input);
        }

        public static string CleanGeneric(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Basic cleanup: trim, collapse spaces, remove control chars
            var cleaned = input.Trim();
            cleaned = Regex.Replace(cleaned, @"\s+", " ");
            cleaned = Regex.Replace(cleaned, @"[\u0000-\u001F]", "");
            return cleaned;
        }
    }
}
