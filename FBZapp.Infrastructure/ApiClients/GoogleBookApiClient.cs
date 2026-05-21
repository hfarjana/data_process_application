using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FBZapp.Infrastructure.ApiClients
{
    public class GoogleBookApiClient : IBookApiService
    {
        private readonly HttpClient _httpClient;

        public GoogleBookApiClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            _httpClient = new HttpClient();
        }

        public async Task<BookApiResult> SearchBookAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return NotFoundResult();
            }

            BookApiResult googleResult = await SearchGoogleBooksAsync(searchTerm);

            if (googleResult.IsFound && !string.IsNullOrWhiteSpace(googleResult.CoverImageUrl))
            {
                return googleResult;
            }

            BookApiResult openLibraryResult = await SearchOpenLibraryAsync(searchTerm);

            if (openLibraryResult.IsFound)
            {
                return openLibraryResult;
            }

            if (googleResult.IsFound)
            {
                return googleResult;
            }

            return NotFoundResult();
        }

        private async Task<BookApiResult> SearchGoogleBooksAsync(string query)
        {
            string safeSearchTerm = Uri.EscapeDataString(query);

            string url = "https://www.googleapis.com/books/v1/volumes?q="
                         + safeSearchTerm
                         + "&maxResults=5";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return NotFoundResult();
            }

            string json = await response.Content.ReadAsStringAsync();
            JObject data = JObject.Parse(json);

            JToken items = data["items"];

            if (items == null || !items.HasValues)
            {
                return NotFoundResult();
            }

            foreach (JToken item in items)
            {
                JToken volumeInfo = item["volumeInfo"];

                if (volumeInfo == null)
                {
                    continue;
                }

                string title = GetValue(volumeInfo, "title");
                string publisher = GetValue(volumeInfo, "publisher");
                string publishedDate = GetValue(volumeInfo, "publishedDate");
                string description = GetValue(volumeInfo, "description");
                string authors = GetAuthors(volumeInfo);
                string isbn = GetIsbn(volumeInfo);
                string googleThumbnailUrl = GetGoogleThumbnailUrl(volumeInfo);
                string openLibraryCoverUrl = BuildOpenLibraryCoverUrlFromIsbn(isbn);

                string finalCoverUrl = !string.IsNullOrWhiteSpace(googleThumbnailUrl)
                    ? googleThumbnailUrl
                    : openLibraryCoverUrl;

                return new BookApiResult
                {
                    IsFound = true,
                    Title = string.IsNullOrWhiteSpace(title) ? query : title,
                    Authors = authors,
                    Publisher = string.IsNullOrWhiteSpace(publisher) ? "Unknown publisher" : publisher,
                    PublishedDate = string.IsNullOrWhiteSpace(publishedDate) ? "Unknown date" : publishedDate,
                    Description = string.IsNullOrWhiteSpace(description) ? "No description available" : description,
                    ThumbnailUrl = googleThumbnailUrl,
                    CoverImageUrl = finalCoverUrl,
                    ISBN = isbn
                };
            }

            return NotFoundResult();
        }

        private async Task<BookApiResult> SearchOpenLibraryAsync(string query)
        {
            string safeSearchTerm = Uri.EscapeDataString(query);

            string url = "https://openlibrary.org/search.json?title="
                         + safeSearchTerm
                         + "&limit=5";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return NotFoundResult();
            }

            string json = await response.Content.ReadAsStringAsync();
            JObject data = JObject.Parse(json);

            JToken docs = data["docs"];

            if (docs == null || !docs.HasValues)
            {
                return NotFoundResult();
            }

            foreach (JToken doc in docs)
            {
                string title = GetValue(doc, "title");
                string publishedYear = GetValue(doc, "first_publish_year");

                string authors = "Unknown author";

                if (doc["author_name"] != null && doc["author_name"].HasValues)
                {
                    authors = string.Join(", ", doc["author_name"]).Replace("\"", "");
                }

                string isbn = "missing";

                if (doc["isbn"] != null && doc["isbn"].HasValues)
                {
                    isbn = doc["isbn"].First.ToString();
                }

                string coverUrl = string.Empty;

                if (doc["cover_i"] != null)
                {
                    coverUrl = "https://covers.openlibrary.org/b/id/"
                               + doc["cover_i"].ToString()
                               + "-M.jpg";
                }
                else if (isbn != "missing")
                {
                    coverUrl = BuildOpenLibraryCoverUrlFromIsbn(isbn);
                }

                return new BookApiResult
                {
                    IsFound = true,
                    Title = string.IsNullOrWhiteSpace(title) ? query : title,
                    Authors = authors,
                    Publisher = "Open Library",
                    PublishedDate = string.IsNullOrWhiteSpace(publishedYear) ? "Unknown date" : publishedYear,
                    Description = "Book/comic details retrieved from Open Library.",
                    ThumbnailUrl = coverUrl,
                    CoverImageUrl = coverUrl,
                    ISBN = isbn
                };
            }

            return NotFoundResult();
        }

        private string GetValue(JToken token, string fieldName)
        {
            if (token == null || token[fieldName] == null)
            {
                return string.Empty;
            }

            return token[fieldName].ToString();
        }

        private string GetAuthors(JToken volumeInfo)
        {
            if (volumeInfo["authors"] == null || !volumeInfo["authors"].HasValues)
            {
                return "Unknown author";
            }

            return string.Join(", ", volumeInfo["authors"]).Replace("\"", "");
        }

        private string GetIsbn(JToken volumeInfo)
        {
            if (volumeInfo["industryIdentifiers"] == null ||
                !volumeInfo["industryIdentifiers"].HasValues)
            {
                return "missing";
            }

            foreach (JToken identifier in volumeInfo["industryIdentifiers"])
            {
                string type = GetValue(identifier, "type");
                string value = GetValue(identifier, "identifier");

                if (type == "ISBN_13" && !string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }
            }

            foreach (JToken identifier in volumeInfo["industryIdentifiers"])
            {
                string value = GetValue(identifier, "identifier");

                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }
            }

            return "missing";
        }

        private string GetGoogleThumbnailUrl(JToken volumeInfo)
        {
            if (volumeInfo["imageLinks"] == null)
            {
                return string.Empty;
            }

            string thumbnailUrl = string.Empty;

            if (volumeInfo["imageLinks"]["thumbnail"] != null)
            {
                thumbnailUrl = volumeInfo["imageLinks"]["thumbnail"].ToString();
            }
            else if (volumeInfo["imageLinks"]["smallThumbnail"] != null)
            {
                thumbnailUrl = volumeInfo["imageLinks"]["smallThumbnail"].ToString();
            }

            if (!string.IsNullOrWhiteSpace(thumbnailUrl))
            {
                thumbnailUrl = thumbnailUrl.Replace("http://", "https://");
            }

            return thumbnailUrl;
        }

        private string BuildOpenLibraryCoverUrlFromIsbn(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn) || isbn == "missing")
            {
                return string.Empty;
            }

            return "https://covers.openlibrary.org/b/isbn/" + isbn + "-M.jpg";
        }

        private BookApiResult NotFoundResult()
        {
            return new BookApiResult
            {
                IsFound = false,
                Title = string.Empty,
                Authors = string.Empty,
                Publisher = string.Empty,
                PublishedDate = string.Empty,
                Description = string.Empty,
                ThumbnailUrl = string.Empty,
                CoverImageUrl = string.Empty,
                ISBN = "missing"
            };
        }
    }
}