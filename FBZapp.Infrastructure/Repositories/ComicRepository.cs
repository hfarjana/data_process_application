using System.Collections.Generic;
using System.Linq;
using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;

namespace FBZapp.Infrastructure.Repositories
{
    public class ComicRepository : IComicRepository
    {
        private readonly List<Comic> _comics;

        public ComicRepository(List<Comic> comics)
        {
            _comics = comics ?? new List<Comic>();
        }

        public List<Comic> GetAllComics()
        {
            return _comics;
        }

        public Comic GetComicByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return null;

            return _comics.FirstOrDefault(c =>
                !string.IsNullOrWhiteSpace(c.Title) &&
                c.Title.ToLower() == title.ToLower());
        }

        public void AddComic(Comic comic)
        {
            if (comic == null)
                return;

            _comics.Add(comic);
        }

        public void RemoveComic(Comic comic)
        {
            if (comic == null)
                return;

            _comics.Remove(comic);
        }
    }
}

