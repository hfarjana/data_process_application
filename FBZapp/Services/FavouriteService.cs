using FBZapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Services
{
  public class FavouriteService :IFavouriteService

  {
        private readonly List<Comic> _favourites = new List<Comic>();

        public void AddToFavourites(Comic comic)
        {
            if (!_favourites.Any(c => c.Title == comic.Title))
                _favourites.Add(comic);
        }

        public void RemoveFromFavourites(Comic comic)
        {
            _favourites.RemoveAll(c => c.Title == comic.Title);
        }

        public List<Comic> GetFavourites()
        {
            return _favourites.ToList();
        }

        public bool IsFavourite(Comic comic)
        {
            return _favourites.Any(c => c.Title == comic.Title);
        }

    }
}
