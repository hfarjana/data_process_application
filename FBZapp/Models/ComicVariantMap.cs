using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Models
{
   public sealed class ComicVariantMap : ClassMap<ComicVariant>
   {
     public ComicVariantMap()
     {

      Map(m => m.Title).Name("Other titles");
      Map(m => m.Author).Name("Name");
      Map(m => m.Publisher).Name("Publisher");
      Map(m => m.ISBN).Name("ISBN");
      Map(m => m.Genre).Name("Genre");
      Map(m => m.Languages).Name("Languages");
      Map(m => m.Description).Name("Notes", "Notes", "Notes", "Notes");
      Map(m => m.RawYear).Name("Date of publication");






     }
   }
}
