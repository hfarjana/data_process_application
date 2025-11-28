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
     Map(m => m.Title).Name("Title");
     Map(m => m.Author).Name("Name");                      // CSV column 'Name' -> Author
     Map(m => m.Genre).Name("Genre");
     Map(m => m.Publisher).Name("Publisher");
     Map(m => m.RawYear).Name("Date of publication");      // raw year string
     Map(m => m.ISBN).Name("ISBN");
    

     }
   }
}
