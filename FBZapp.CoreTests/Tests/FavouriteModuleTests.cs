using NUnit.Framework;
using FBZapp.CoreTests.Stubs;

namespace FBZapp.CoreTests.Tests
{
    [TestFixture]
    public class FavouriteModuleTests
    {
        [Test]
        public void AddToFavourites_Should_IncreaseCount()
        {
            var service = new StubFavouriteService();
            var comic = StubComicData.GetSampleComics()[0];

            service.AddToFavourites(comic);

            Assert.That(service.GetCount(), Is.EqualTo(1));
        }

        [Test]
        public void AddDuplicateFavourite_Should_NotIncreaseCount()
        {
            var service = new StubFavouriteService();
            var comic = StubComicData.GetSampleComics()[0];

            service.AddToFavourites(comic);
            service.AddToFavourites(comic);

            Assert.That(service.GetCount(), Is.EqualTo(1));
        }

        [Test]
        public void RemoveFromFavourites_Should_DecreaseCount()
        {
            var service = new StubFavouriteService();
            var comic = StubComicData.GetSampleComics()[0];

            service.AddToFavourites(comic);
            service.RemoveFromFavourites(comic);

            Assert.That(service.GetCount(), Is.EqualTo(0));
        }
    }
}