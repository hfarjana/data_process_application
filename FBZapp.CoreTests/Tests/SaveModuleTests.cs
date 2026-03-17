using NUnit.Framework;
using FBZapp.CoreTests.Stubs;

namespace FBZapp.CoreTests.Tests
{
    [TestFixture]
    public class SaveModuleTests
    {
        [Test]
        public void SaveComic_Should_StoreComicSuccessfully()
        {
            var service = new StubSaveService();
            var comic = StubComicData.GetSampleComics()[0];

            service.SaveComic(comic);

            Assert.That(service.GetSavedCount(), Is.EqualTo(1));
        }
    }
}
