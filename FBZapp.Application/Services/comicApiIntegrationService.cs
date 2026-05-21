using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FBZapp.Application.Services
{
    public class ComicApiIntegrationService : IComicApiIntegrationService
    {
        private readonly IBookApiService _bookApiService;

        public ComicApiIntegrationService(IBookApiService bookApiService)
        {
            _bookApiService = bookApiService;
        }

        public async Task EnrichComicWithApiDataAsync(Comic comic)
        {
            if (comic == null)
            {
                return;
            }

            BookApiResult apiResult = await _bookApiService.SearchBookAsync(comic.Title);

            if (!apiResult.IsFound)
            {
                string isbn = GetFirstValidIsbn(comic.ISBN);

                if (!string.IsNullOrWhiteSpace(isbn))
                {
                    apiResult = await _bookApiService.SearchBookAsync(isbn);
                }
            }

            if (!apiResult.IsFound)
            {
                comic.IsApiEnriched = false;
                return;
            }

            comic.ApiTitle = apiResult.Title;
            comic.ApiAuthors = apiResult.Authors;
            comic.ApiPublisher = apiResult.Publisher;
            comic.ApiPublishedDate = apiResult.PublishedDate;
            comic.ApiDescription = apiResult.Description;
            comic.ApiThumbnailUrl = apiResult.ThumbnailUrl;
            comic.ApiISBN = apiResult.ISBN;
            comic.ApiSource = "Google Books API";
            comic.IsApiEnriched = true;
        }

        private string GetFirstValidIsbn(string isbnText)
        {
            if (string.IsNullOrWhiteSpace(isbnText))
            {
                return string.Empty;
            }

            return isbnText
                .Split(';')
                .Select(x => x.Trim())
                .FirstOrDefault(x =>
                    !string.IsNullOrWhiteSpace(x) &&
                    !x.Equals("missing", StringComparison.OrdinalIgnoreCase)) ?? string.Empty;
        }
    }
}
