using FBZapp.Models;
using NUnit.Framework;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FBZapp.Tests
{
    public static class TestData
    {
        public static List<Comic> GetSampleComics()
        {
            return new List<Comic>
            {
                new Comic
                {
                 Title = "Crossover",
                 Author = "Spurrier",
                 Genre = "Horror",
                 Publisher ="Avatar",
                 Languages = "English",

                 Variants = new List<ComicVariant>
                 {
                   new ComicVariant {RawYear = "2017", ISBN = "111" }
                 }



                },
                new Comic
                {
                  Title = "American Vampire",
                  Author = "Willingham",
                  Genre = "Fantasy",
                  Publisher = "DC Comics",
                  Languages = "English",
                  Variants = new List<ComicVariant>
                  {
                    new ComicVariant { RawYear = "2007", ISBN = "222" }
                  }
                }
            };
        }
    }
}
