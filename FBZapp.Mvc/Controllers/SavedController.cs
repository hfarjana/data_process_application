using System;
using System.Web.Mvc;
using FBZapp.Domain.Entities;
using FBZapp.Infrastructure.Repositories;

namespace FBZapp.Mvc.Controllers
{
    public class SavedController : Controller
    {
        [HttpPost]
        public ActionResult SaveComic(string comicTitle)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = (int)Session["UserId"];

            var repo = new SavedSearchRepository();
            repo.SaveComic(new SavedComic
            {
                UserId = userId,
                ComicTitle = comicTitle,
                SavedDate = DateTime.Now
            });

            return RedirectToAction("Index", "Comics");
        }


        public ActionResult MyComics()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = (int)Session["UserId"];

            var repo = new SavedSearchRepository();
            var savedComics = repo.GetSavedComicsByUserId(userId);

            return View(savedComics);
        }
        [HttpPost]
        public ActionResult SaveSearch(string queryText, string genre, string sortOption)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (string.IsNullOrWhiteSpace(queryText) &&
                string.IsNullOrWhiteSpace(genre) &&
                string.IsNullOrWhiteSpace(sortOption))
            {
                return RedirectToAction("Index", "Comics");
            }

            var userId = (int)Session["UserId"];

            var repo = new SavedSearchRepository();
            repo.SaveSearch(new SavedSearch
            {
                UserId = userId,
                QueryText = queryText,
                Genre = genre,
                SortOption = sortOption,
                SavedDate = DateTime.Now
            });

            return RedirectToAction("MySearches", "Saved");
        }

        public ActionResult MySearches()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = (int)Session["UserId"];

            var repo = new SavedSearchRepository();
            var savedSearches = repo.GetSavedSearchesByUserId(userId);

            return View(savedSearches);
        }
    }
}