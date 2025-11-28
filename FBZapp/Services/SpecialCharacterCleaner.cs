using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FBZapp.Services
{
  public static class SpecialCharacterCleaner
    {
        private static readonly Regex CleanRegex =
                new Regex(@"[^a-zA-Z0-9\s.,:;!'""()?&-]", RegexOptions.Compiled);

        public static string CleanTitle(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return CleanRegex.Replace(input, "").Trim();
        }

        public static string CleanGeneric(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return CleanRegex.Replace(input, "").Trim();
        }

    }
}
