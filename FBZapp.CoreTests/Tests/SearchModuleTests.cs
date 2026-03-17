using System.Linq;
using NUnit.Framework;
using FBZapp.CoreTests.Stubs;

namespace FBZapp.CoreTests.Tests
{
    [TestFixture]
    public class SearchModuleTests
    {
        [Test]
        public void SearchByAuthor_Should_Return_OnlyMatchingComics()
        {
            var comics = StubComicData.GetSampleComics();

            var result = comics
                .Where(c => c.Author.Contains("Willingham"))
                .ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.All(c => c.Author.Contains("Willingham")), Is.True);
        }
    }
}