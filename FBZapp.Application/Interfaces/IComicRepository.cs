
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBZapp.Domain.Entities;


namespace FBZapp.Application.Interfaces
{
  public interface IComicRepository
  {
   List<Comic> GetAllComics();
   Comic GetComicByTitle(string title);
   void AddComic(Comic comic);
   void RemoveComic(Comic comic);

  }




}
