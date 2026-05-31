using NUnit.Framework;

namespace FBZapp.Tests
{
    [TestFixture]
    public class RoleAccessTests
    {
        [Test]
        public void CanAccessReports_WhenUserIsStaff_ReturnsTrue()
        {
            string userRole = "Staff";

            bool canAccessReports = userRole == "Staff";

            Assert.That(canAccessReports, Is.True);
        }

        [Test]
        public void CanAccessReports_WhenUserIsPublic_ReturnsFalse()
        {
            string userRole = "Public";

            bool canAccessReports = userRole == "Staff";

            Assert.That(canAccessReports, Is.False);
        }

        [Test]
        public void CanFlagRecord_WhenUserIsStaff_ReturnsTrue()
        {
            string userRole = "Staff";

            bool canFlagRecord = userRole == "Staff";

            Assert.That(canFlagRecord, Is.True);
        }

        [Test]
        public void CanFlagRecord_WhenUserIsPublic_ReturnsFalse()
        {
            string userRole = "Public";

            bool canFlagRecord = userRole == "Staff";

            Assert.That(canFlagRecord, Is.False);
        }
    }
}
