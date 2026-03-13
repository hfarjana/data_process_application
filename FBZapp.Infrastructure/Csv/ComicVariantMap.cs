using CsvHelper.Configuration;
using FBZapp.Domain.Entities;

namespace FBZapp.Infrastructure.Csv
{
    public sealed class ComicVariantMap : ClassMap<ComicVariant>
    {
        public ComicVariantMap()
        {
            Map(m => m.Title).Name("Title");
            Map(m => m.Author).Name("Author");
            Map(m => m.Genre).Name("Genre");
            Map(m => m.Publisher).Name("Publisher");
            Map(m => m.Notes).Name("Notes");
            Map(m => m.RawYear).Name("Date of publication");
            Map(m => m.ISBN).Name("ISBN");
            Map(m => m.Languages).Name("Language");
            Map(m => m.Description).Name("Description");
        }
    }
}

