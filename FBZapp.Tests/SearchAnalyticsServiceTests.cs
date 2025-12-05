using FBZapp.Services;
using NUnit.Framework;

namespace FBZapp.Tests
{
    [TestFixture]
    public class SearchAnalyticsServiceTests
    {
        private SearchAnalyticsService _service;

        [SetUp]
        public void Setup()
        {
            _service = new SearchAnalyticsService();
        }

        [Test]
        public void TrackSearch_IncreasesSearchCount_IfTheSearch_Increase()
        {
            // Arrange + Act
            _service.TrackSearch("fantasy", 10);

            // Assert
            var top = _service.GetTopSearches(1);
            Assert.That(top["fantasy"], Is.EqualTo(1));
        }

        [Test]
        public void TrackSearch_TracksMultipleDifferentQueries_If ()
        {
            _service.TrackSearch("fantasy", 10);
            _service.TrackSearch("horror", 5);

            var top = _service.GetTopSearches(2);

            Assert.That(top.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetTopResults_ReturnsCorrectCounts()
        {
            _service.TrackSearch("fantasy", 12);
            _service.TrackSearch("fantasy", 8);

            var results = _service.GetTopResults(1);

            Assert.That(results["fantasy"], Is.EqualTo(20));
        }
    }
}
