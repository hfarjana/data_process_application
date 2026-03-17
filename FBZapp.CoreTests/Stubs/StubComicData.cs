using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.CoreTests.Stubs
{
    public static class StubComicData
    {
        public static List<Comic> GetSampleComics()
        {
            return new List<Comic>
            {
                new Comic
                {
                    Title = "Fables",
                    Author = "Willingham",
                    Genre = "Fantasy",
                    Publisher = "DC"
                },
                new Comic
                {
                    Title = "Swamp Thing",
                    Author = "Moore",
                    Genre = "Horror",
                    Publisher = "Vertigo"
                },
                new Comic
                {
                    Title = "Saga",
                    Author = "Vaughan",
                    Genre = "Science Fiction",
                    Publisher = "Image"
                }
            };
        }
    }
}