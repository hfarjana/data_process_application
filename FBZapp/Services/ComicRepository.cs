using FBZapp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FBZapp.Services
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
            return _comics.FirstOrDefault(c =>
                c.Title != null &&
                c.Title.ToLower() == title.ToLower());
        }

        public void AddComic(Comic comic)
        {
            if (comic != null)
                _comics.Add(comic);
        }

        public void RemoveComic(Comic comic)
        {
            if (comic != null)
                _comics.Remove(comic);
        }
    }
}

