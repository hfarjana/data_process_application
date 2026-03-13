using System.Collections.Generic;
using System.Linq;
using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IComicRepository _comicRepository;

        public SearchService(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }

        public List<Comic> GlobalSearch(string query)
        {
            var comics = _comicRepository.GetAllComics();

            if (string.IsNullOrWhiteSpace(query))
                return comics;

            query = query.Trim().ToLower();

            return comics
                .Where(c => !string.IsNullOrWhiteSpace(c.Title) &&
                            c.Title.ToLower().Contains(query))
                .ToList();
        }

        public List<Comic> FilterByGenre(List<Comic> comics, string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return comics;

            return comics
                .Where(c => !string.IsNullOrWhiteSpace(c.Genre) &&
                            c.Genre.ToLower().Contains(genre.ToLower()))
                .ToList();
        }

        public List<Comic> ApplySorting(List<Comic> comics, string sortOption)
        {
            if (string.IsNullOrWhiteSpace(sortOption))
                return comics;

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

        public List<Comic> GroupComics(List<Comic> comics, string groupBy)
        {
            if (string.IsNullOrWhiteSpace(groupBy))
                return comics;

            switch (groupBy)
            {
                case "Author":
                    return comics.OrderBy(c => c.Author).ThenBy(c => c.Title).ToList();

                case "Year":
                    return comics.OrderBy(c => c.Year).ThenBy(c => c.Title).ToList();

                default:
                    return comics;
            }
        }

        public List<Comic> AdvancedSearch(string author, string genre, int? year, string language, string nameType)
        {
            var comics = _comicRepository.GetAllComics();

            if (!string.IsNullOrWhiteSpace(author))
            {
                comics = comics
                    .Where(c => !string.IsNullOrWhiteSpace(c.Author) &&
                                c.Author.ToLower().Contains(author.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                comics = comics
                    .Where(c => !string.IsNullOrWhiteSpace(c.Genre) &&
                                c.Genre.ToLower().Contains(genre.ToLower()))
                    .ToList();
            }

            if (year.HasValue)
            {
                comics = comics
                    .Where(c => c.Year == year.Value)
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(language))
            {
                comics = comics
                    .Where(c => !string.IsNullOrWhiteSpace(c.Languages) &&
                                c.Languages.ToLower().Contains(language.ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(nameType))
            {
                comics = comics
                    .Where(c => !string.IsNullOrWhiteSpace(c.Title) &&
                                c.Title.ToLower().Contains(nameType.ToLower()))
                    .ToList();
            }

            return comics;
        }
    }
}

