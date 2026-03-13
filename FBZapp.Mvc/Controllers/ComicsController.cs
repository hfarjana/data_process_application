using FBZapp.Application.Services;
using FBZapp.Infrastructure.Data;
using FBZapp.Infrastructure.Repositories;
using FBZapp.Mvc.Models;
using System.Linq;
using System.Web.Mvc;

namespace FBZapp.Mvc.Controllers
{
    public class ComicsController : Controller
    {
        public ActionResult Index(string query, string genre, string sortOption, string groupBy)
        {
            var csvPath = Server.MapPath("~/App_Data/titles.csv");

            var loader = new CsvDataLoader(csvPath);
            var comicsList = loader.LoadComics();

            ViewBag.LoadedCount = comicsList.Count;

            var repo = new ComicRepository(comicsList);
            var searchService = new SearchService(repo);

            var results = searchService.GlobalSearch(query);
            results = searchService.FilterByGenre(results, genre);
            results = searchService.ApplySorting(results, sortOption);
            results = searchService.GroupComics(results, groupBy);

            var analyticsRepo = new AnalyticsRepository();
            int? userId = Session["UserId"] != null ? (int?)Session["UserId"] : null;

            analyticsRepo.LogSearch(userId, query);
            analyticsRepo.LogSearchResults(query, results.Select(c => c.Title).ToList());


           results = results.Take(100).ToList();

            var vm = new ComicSearchViewModel
            {
                Query = query,
                Genre = genre,
                SortOption = sortOption,
                GroupBy = groupBy,
                Results = results
            };

            return View(vm);
        }


        public ActionResult AdvancedSearch(string author, string genre, int? year, string editionLanguage, string nameType)
        {
            var csvPath = Server.MapPath("~/App_Data/titles.csv");

            var loader = new CsvDataLoader(csvPath);
            var comicsList = loader.LoadComics();

            var repo = new ComicRepository(comicsList);
            var searchService = new SearchService(repo);

            var results = searchService.AdvancedSearch(author, genre, year, editionLanguage, nameType);

            var vm = new ComicSearchViewModel
            {
                Author = author,
                Genre = genre,
                Year = year,
                EditionLanguage = editionLanguage,
                NameType = nameType,
                Results = results
            };

            return View(vm);
        }








        public ActionResult Details(string title)
        {
            var csvPath = Server.MapPath("~/App_Data/titles.csv");

            var loader = new CsvDataLoader(csvPath);
            var comicsList = loader.LoadComics();

            var repo = new ComicRepository(comicsList);
            var comic = repo.GetComicByTitle(title);

            if (comic == null)
                return HttpNotFound();

            return View(comic);
        }
    }
}