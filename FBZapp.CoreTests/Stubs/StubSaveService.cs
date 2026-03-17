using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.CoreTests.Stubs
{
    public class StubSaveService
    {
        private readonly List<Comic> _savedComics = new List<Comic>();

        public void SaveComic(Comic comic)
        {
            _savedComics.Add(comic);
        }

        public int GetSavedCount()
        {
            return _savedComics.Count;
        }
    }
}