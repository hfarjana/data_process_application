 using CsvHelper;
using CsvHelper.Configuration;
using FBZapp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FBZapp.Services
{
    public class CsvDataLoader
    {
        private readonly string _filePath;

        public CsvDataLoader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Comic> LoadComics()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("CSV file not found.", _filePath);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                DetectDelimiter = true,
                BadDataFound = null,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(_filePath, Encoding.GetEncoding("Windows-1252")))
            using (var csv = new CsvReader(reader, config))
            {
               
                csv.Context.RegisterClassMap<ComicVariantMap>();
                var variantRows = csv.GetRecords<ComicVariant>().ToList();

                foreach (var row in variantRows)
                {
                    row.Title = SpecialCharacterCleaner.CleanTitle(row.Title);
                    row.Author = SpecialCharacterCleaner.CleanGeneric(row.Author);
                    row.Genre = SpecialCharacterCleaner.CleanGeneric(row.Genre);
                    row.Publisher = SpecialCharacterCleaner.CleanGeneric(row.Publisher);
                    row.Languages = SpecialCharacterCleaner.CleanGeneric(row.Languages);
                    row.Notes = SpecialCharacterCleaner.CleanGeneric(row.Notes);

                    if (string.IsNullOrWhiteSpace(row.ISBN))
                        row.ISBN = "missing";
                }

               
                var filtered = variantRows
                    .Where(r => r.Genre != null &&
                               (r.Genre.Contains("Fantasy") ||
                                r.Genre.Contains("Horror") ||
                                r.Genre.Contains("Science Fiction")))
                    .ToList();

                var comics = filtered
                    .GroupBy(r => (r.Title ?? "").Trim().ToLower())
                    .Select(group =>
                    {
                        var first = group.First();

                        
                        var years = group
                            .Select(v =>
                            {
                                int y;
                                if (int.TryParse(v.RawYear, out y))
                                    return y;
                                else
                                    return (int?)null;
                            })
                            .Where(y => y.HasValue)
                            .Select(y => y.Value)
                            .ToList();

                        int year = years.Any() ? years.Min() : 0;

                        var comic = new Comic
                        {
                            Title = CleanPrimaryTitle(first.Title),
                            Author = first.Author,
                            Genre = first.Genre,
                            Publisher = first.Publisher,
                            Languages = first.Languages,
                            Description = string.Join(" | ", group.Select(v => v.Description)
                                .Where(d => !string.IsNullOrWhiteSpace(d))
                                .Distinct()),
                            Variants = new List<ComicVariant>()
                        };

                        foreach (var row in group)
                        {
                            comic.Variants.Add(new ComicVariant
                            {
                                Title = CleanPrimaryTitle(row.Title),
                                Author = row.Author,
                                Genre = row.Genre,
                                Publisher = row.Publisher,
                                RawYear = row.RawYear,
                                ISBN = row.ISBN
                                
                            });
                        }

                        return comic;
                    })
                    .ToList();

                return comics;

            }
        }
    }
}



