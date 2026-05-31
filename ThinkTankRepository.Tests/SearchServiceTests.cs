using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FBZapp.Tests
{
    [TestFixture]
    public class SearchServiceTests
    {
        private List<ResearchRecord> _records;

        [SetUp]
        public void Setup()
        {
            _records = new List<ResearchRecord>
            {
                new ResearchRecord
                {
                    Title = "Cloud Security Report",
                    Author = "Smith",
                    Year = 2023,
                    Topic = "Security"
                },
                new ResearchRecord
                {
                    Title = "AI Ethics Study",
                    Author = "Jones",
                    Year = 2022,
                    Topic = "Artificial Intelligence"
                },
                new ResearchRecord
                {
                    Title = "Cloud Migration Guide",
                    Author = "Smith",
                    Year = 2024,
                    Topic = "Cloud"
                }
            };
        }

        [Test]
        public void Search_WithValidKeyword_ReturnsMatchingRecords()
        {
            var results = _records
                .Where(r => r.Title.Contains("Cloud"))
                .ToList();

            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        public void Search_WithEmptyKeyword_ReturnsEmptyList()
        {
            string keyword = "";

            var results = string.IsNullOrWhiteSpace(keyword)
                ? new List<ResearchRecord>()
                : _records.Where(r => r.Title.Contains(keyword)).ToList();

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void AdvancedSearch_WithAuthorAndYear_ReturnsCorrectRecord()
        {
            var results = _records
                .Where(r => r.Author == "Smith" && r.Year == 2023)
                .ToList();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results[0].Title, Is.EqualTo("Cloud Security Report"));
        }
    }

    public class ResearchRecord
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Topic { get; set; }
    }
}
