using NUnit.Framework;
using FBZapp.Services;
using FBZapp.Models;
using System.Collections.Generic;

namespace FBZapp.Tests
{
    [TestFixture]
    public class FavouriteServiceTests
    {
        private FavouriteService _service;
        private Comic _comic1;
        private Comic _comic2;

        [SetUp]
        public void Setup()
        {
            _service = new FavouriteService();

            _comic1 = new Comic { Title = "Crossover" };
            _comic2 = new Comic { Title = "Ghost Rider" };
        }

        [Test]
        public void AddToFavourites_AddsComic_WhenNotExists()
        {
            //arrange
            _service.AddToFavourites(_comic1);
            //act
            var result = _service.GetFavourites();
         //assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Title, Is.EqualTo("Crossover"));
        }

        [Test]
        public void AddToFavourites_DoesNotAddDuplicate()
        {
            _service.AddToFavourites(_comic1);
            _service.AddToFavourites(_comic1); 

            var result = _service.GetFavourites();

            Assert.That(result.Count, Is.EqualTo(1)); 
        }

        [Test]
        public void RemoveFromFavourites_RemovesComic()
        {
            _service.AddToFavourites(_comic1);
            _service.RemoveFromFavourites(_comic1);

            var result = _service.GetFavourites();

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void IsFavourite_ReturnsTrue_WhenComicIsSaved()
        {
          // arrange
            _service.AddToFavourites(_comic2);
         //act
            bool exists = _service.IsFavourite(_comic2);
         //assert
            Assert.That(exists, Is.True);
        }

        [Test]
        public void IsFavourite_ReturnsFalse_WhenComicNotSaved()
        {
            bool exists = _service.IsFavourite(_comic1);

            Assert.That(exists, Is.False);
        }

        [Test]
        public void GetFavourites_ReturnsCopy_NotReference()
        {
            //Arrange
            _service.AddToFavourites(_comic1);
         //ACt
            var favs = _service.GetFavourites();
            favs.Clear(); 

         //assert
            Assert.That(_service.GetFavourites().Count, Is.EqualTo(1));
        }
    }
}
