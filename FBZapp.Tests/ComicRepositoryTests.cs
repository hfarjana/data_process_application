using NUnit.Framework;
using FBZapp.Services;
using FBZapp.Models;
using System.Collections.Generic;

namespace FBZapp.Tests
{
    [TestFixture]
    public class ComicRepositoryTests
    {
        private ComicRepository _repo;
        private List<Comic> _sample;

        [SetUp]
        public void Setup()
        {
            _sample = TestData.GetSampleComics();
            _repo = new ComicRepository(_sample);
        }

        [Test]
        public void GetAllComics_ReturnsAllItems()
        {
            var result = _repo.GetAllComics();

            Assert.That(result.Count, Is.EqualTo(_sample.Count));
        }

        [Test]
        public void GetAllComics_ReturnsCopy_NotReference()
        {
            var result = _repo.GetAllComics();

           
            result.Clear();

          
            Assert.That(_repo.GetAllComics().Count, Is.EqualTo(_sample.Count));
        }

        [Test]
        public void Repository_HandlesEmptyList()
        {
            var repo = new ComicRepository(new List<Comic>());

            var result = repo.GetAllComics();

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void Repository_DoesNotCrash_WhenNullPassed()
        {
            var repo = new ComicRepository(null);

            var result = repo.GetAllComics();

            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}

