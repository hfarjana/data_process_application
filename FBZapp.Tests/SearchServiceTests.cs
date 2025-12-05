using FBZapp.Models;
using FBZapp.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace FBZapp.Tests
{
    [TestFixture]
    public class SearchServiceTests
    {
        private SearchService _service;
        private List<Comic> _comics;

        [SetUp]
        public void Setup()
        {
            _comics = TestData.GetSampleComics();
            var repo = new ComicRepository(_comics);
            _service = new SearchService(repo);
        }

        //  GLOBAL SEARCH 

        [Test]
        public void GlobalSearch_FindsByTitle()
        {
            var result = _service.GlobalSearch("Cross");
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Title, Is.EqualTo("Crossover"));
        }

        [Test]
        public void GlobalSearch_FindsByAuthor()
        {
            var result = _service.GlobalSearch("Willingham");
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Author, Is.EqualTo("Willingham"));
        }

        //  ADVANCED SEARCH 

        [Test]
        public void AdvancedSearch_FiltersCorrectly()
        {
            var result = _service.AdvancedSearch("Willingham", "DC Comics", 2000, 2010);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        //  GENRE FILTER 

        [Test]
        public void FilterByGenre_ReturnsOnlyHorror()
        {
            var result = _service.FilterByGenre(_comics, "Horror");
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Genre, Is.EqualTo("Horror"));
        }

        //  SORTING 


        [Test]
        public void ApplySorting_SortsDescending()
        {
            var result = _service.ApplySorting(_comics, "Title Z-A");
            Assert.That(result[0].Title, Is.EqualTo("Crossover"));
        }
    }
}

