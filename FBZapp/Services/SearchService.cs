using FBZapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FBZapp.Services
{
    public class SearchService : ISearchService
    {
        private readonly IComicRepository _repository;

        public SearchService(IComicRepository repository)
        {
            _repository = repository;
        }

        // GLOBAL SEARCH
     
        public List<Comic> GlobalSearch(string query)
        {
            var all = _repository.GetAllComics();

            if (string.IsNullOrWhiteSpace(query))
                return all;

            query = query.ToLower();

            return all.Where(c =>
                (!string.IsNullOrEmpty(c.Title) && c.Title.ToLower().Contains(query)) ||
                (!string.IsNullOrEmpty(c.Author) && c.Author.ToLower().Contains(query)) ||
                (!string.IsNullOrEmpty(c.Publisher) && c.Publisher.ToLower().Contains(query)) ||
                c.Year.ToString().Contains(query)
            ).ToList();
        }

        // ADVANCED SEARCH
        
        public List<Comic> AdvancedSearch(string author, string publisher, int yearFrom, int yearTo)
        {
            var all = _repository.GetAllComics();

            if (!string.IsNullOrEmpty(author))
                author = author.ToLower();

            if (!string.IsNullOrEmpty(publisher))
                publisher = publisher.ToLower();

            return all.Where(c =>
                (string.IsNullOrEmpty(author) || (c.Author ?? "").ToLower().Contains(author)) &&
                (string.IsNullOrEmpty(publisher) || (c.Publisher ?? "").ToLower().Contains(publisher)) &&
                c.Year >= yearFrom &&
                c.Year <= yearTo
            ).ToList();
        }


        // SORTING

        public List<Comic> ApplySorting(List<Comic> comics, string sortOption)
        {
            switch (sortOption)
            {
                case "A-Z":
                    return comics.OrderBy(c => c.Title).ToList();
                case "Z-A":
                    return comics.OrderByDescending(c => c.Title).ToList();
                default:
                    return comics;
            }
        }



        // GROUPING

        public List<IGrouping<string, Comic>> GroupComics(List<Comic> comics, string groupOption)
        {
            switch (groupOption)
            {
                case "Author":
                    return comics
                        .Where(c => !string.IsNullOrWhiteSpace(c.Author))
                        .GroupBy(c => c.Author)
                        .ToList();

                case "Year":
                    return comics
                        .GroupBy(c => c.Year.ToString())
                        .ToList();

                default:
                    return new List<IGrouping<string, Comic>>();
            }
        }

        
        // GENRE FILTER
        
        public List<Comic> FilterByGenre(List<Comic> comics, string genre)
        {
            if (string.IsNullOrWhiteSpace(genre) || genre == "All")
                return comics;

            return comics
                .Where(c => c.Genre != null &&
                            c.Genre.IndexOf(genre, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
