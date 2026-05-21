using FBZapp.Application.Services;
using FBZapp.Domain.Entities;
using FBZapp.Infrastructure.ApiClients;
using FBZapp.Infrastructure.Data;
using FBZapp.Infrastructure.Repositories;
using FBZapp.Infrastructure.Services;
using FBZapp.Mvc.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

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

        [HttpPost]

        public async Task<ActionResult> SendSavedEmail(string userEmail, string comicTitle)
        {
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                TempData["Error"] = "Please enter an email address.";
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(comicTitle))
            {
                TempData["Error"] = "Comic title is missing.";
                return RedirectToAction("Index");
            }

            try
            {
                var emailService = new SendGridEmailService();

                await emailService.SendComicSavedEmailAsync(userEmail, comicTitle);

                TempData["Message"] = "Email notification was sent successfully.";
            }
            catch
            {
                TempData["Error"] = "Email notification could not be sent because the SendGrid API key is missing, invalid, expired, or the sender email is not verified.";
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ApiDetails(string title)
        {
            Comic comic = new Comic();

            if (string.IsNullOrWhiteSpace(title))
            {
                TempData["ApiMessage"] = "Please enter a comic title before searching online.";
                return View("Details", comic);
            }

            comic.Title = title;

            try
            {
                GoogleBookApiClient apiClient = new GoogleBookApiClient();

                BookApiResult apiResult = await apiClient.SearchBookAsync(title);

                

                if (apiResult.IsFound)
                {
                    comic.Title = apiResult.Title;
                    comic.Author = apiResult.Authors;
                    comic.Publisher = apiResult.Publisher;
                    comic.Description = apiResult.Description;

                    comic.ApiTitle = apiResult.Title;
                    comic.ApiAuthors = apiResult.Authors;
                    comic.ApiPublisher = apiResult.Publisher;
                    comic.ApiPublishedDate = apiResult.PublishedDate;
                    comic.ApiDescription = apiResult.Description;
                    comic.ApiThumbnailUrl = apiResult.CoverImageUrl;
                    comic.ApiISBN = apiResult.ISBN;
                    comic.ApiSource = "Google Books API and Open Library API";
                    comic.IsApiEnriched = true;

                    TempData["ApiMessage"] = "Online comic details were found successfully.";
                }
                else
                {
                    comic.IsApiEnriched = false;
                    TempData["ApiMessage"] = "No online comic details were found.";
                }
            }
            catch (Exception ex)
            {
                comic.IsApiEnriched = false;
                TempData["ApiMessage"] = "API call failed: " + ex.Message;
            }

            return View("Details", comic);
        }





    }
}

