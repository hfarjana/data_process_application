using FBZapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Services
{
  public interface IFavouriteService 

  {

   void AddToFavourites(Comic comic);
   void RemoveFromFavourites(Comic comic);
   List<Comic> GetFavourites();
   bool IsFavourite(Comic comic);




  }
}
