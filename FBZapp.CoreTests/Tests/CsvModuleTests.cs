using NUnit.Framework;
using FBZapp.CoreTests.Stubs;

namespace FBZapp.CoreTests.Tests
{
    [TestFixture]
    public class CsvModuleTests
    {
        [Test]
        public void LoadCsv_Should_Return_ComicRecords()
        {
            var loader = new StubCsvLoader();

            var result = loader.LoadComics();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.GreaterThan(0));
        }
    }
}
