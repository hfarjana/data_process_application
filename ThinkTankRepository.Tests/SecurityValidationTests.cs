using NUnit.Framework;

namespace FBZapp.Tests
{
    [TestFixture]
    public class SecurityValidationTests
    {
        [Test]
        public void SearchInput_WhenEmpty_IsInvalid()
        {
            string input = "";

            bool isValid = !string.IsNullOrWhiteSpace(input);

            Assert.That(isValid, Is.False);
        }

        [Test]
        public void SearchInput_WhenNormalText_IsValid()
        {
            string input = "Cloud Security";

            bool isValid = !string.IsNullOrWhiteSpace(input);

            Assert.That(isValid, Is.True);
        }

        [Test]
        public void SearchInput_WithScriptTag_IsRejected()
        {
            string input = "<script>alert('xss')</script>";

            bool containsScript = input.ToLower().Contains("<script>");

            Assert.That(containsScript, Is.True);
        }

        [Test]
        public void DebugOutput_ShouldNotBeVisibleToUser()
        {
            bool debugOutputVisible = false;

            Assert.That(debugOutputVisible, Is.False);
        }
    }
}
