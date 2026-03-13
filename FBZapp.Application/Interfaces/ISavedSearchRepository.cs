using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface ISavedSearchRepository
    {
        void SaveComic(SavedComic savedComic);
        void SaveSearch(SavedSearch savedSearch);
        List<SavedComic> GetSavedComicsByUserId(int userId);
        List<SavedSearch> GetSavedSearchesByUserId(int userId);
    }
}
