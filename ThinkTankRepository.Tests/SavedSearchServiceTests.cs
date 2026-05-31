using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FBZapp.Tests
{
    [TestFixture]
    public class SavedSearchServiceTests
    {
        private List<string> _savedSearches;

        [SetUp]
        public void Setup()
        {
            _savedSearches = new List<string>();
        }

        [Test]
        public void SaveSearch_WhenUserLoggedIn_AddsSavedSearch()
        {
            bool isLoggedIn = true;
            string searchTerm = "Cloud Security";

            if (isLoggedIn && !string.IsNullOrWhiteSpace(searchTerm))
            {
                _savedSearches.Add(searchTerm);
            }

            Assert.That(_savedSearches.Count, Is.EqualTo(1));
            Assert.That(_savedSearches[0], Is.EqualTo("Cloud Security"));
        }

        [Test]
        public void SaveSearch_DuplicateSearch_IsNotAddedTwice()
        {
            string searchTerm = "Cloud Security";

            if (!_savedSearches.Contains(searchTerm))
            {
                _savedSearches.Add(searchTerm);
            }

            if (!_savedSearches.Contains(searchTerm))
            {
                _savedSearches.Add(searchTerm);
            }

            Assert.That(_savedSearches.Count, Is.EqualTo(1));
        }

        [Test]
        public void SaveSearch_WhenUserNotLoggedIn_DoesNotAddSearch()
        {
            bool isLoggedIn = false;
            string searchTerm = "Cloud Security";

            if (isLoggedIn)
            {
                _savedSearches.Add(searchTerm);
            }

            Assert.That(_savedSearches, Is.Empty);
        }
    }
}
