using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.Mvc.Models
{
    public class ComicSearchViewModel
    {
        public string Query { get; set; }
        public string Genre { get; set; }
        public string SortOption { get; set; }
        public string GroupBy { get; set; }

        public string Author { get; set; }
        public int? Year { get; set; }
        public string EditionLanguage { get; set; }
        public string NameType { get; set; }

        public List<Comic> Results { get; set; }

        public ComicSearchViewModel()
        {
            Results = new List<Comic>();
        }
    }
}