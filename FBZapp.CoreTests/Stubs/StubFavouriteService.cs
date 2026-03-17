using System.Collections.Generic;
using System.Linq;
using FBZapp.Domain.Entities;

namespace FBZapp.CoreTests.Stubs
{
    public class StubFavouriteService
    {
        private readonly List<Comic> _favourites = new List<Comic>();

        public void AddToFavourites(Comic comic)
        {
            if (!_favourites.Any(c => c.Title == comic.Title))
            {
                _favourites.Add(comic);
            }
        }

        public void RemoveFromFavourites(Comic comic)
        {
            var existing = _favourites.FirstOrDefault(c => c.Title == comic.Title);

            if (existing != null)
            {
                _favourites.Remove(existing);
            }
        }

        public int GetCount()
        {
            return _favourites.Count;
        }
    }
}
