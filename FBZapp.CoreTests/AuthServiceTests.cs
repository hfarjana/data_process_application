using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FBZapp.Application.Interfaces;
using FBZapp.Application.Services;
using FBZapp.Domain.Entities;

namespace FBZapp.CoreTests
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User GetByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }

    [TestFixture]
    public class AuthServiceTests
    {
        [Test]
        public void Register_Should_Add_New_User()
        {
            var repo = new FakeUserRepository();
            var service = new AuthService(repo);

            var result = service.Register("far", "123", "Staff");

            Assert.That(result, Is.True);

            var user = repo.GetByUsername("far");
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Role, Is.EqualTo("Staff"));
        }

        [Test]
        public void Register_Should_Return_False_When_Username_Already_Exists()
        {
            var repo = new FakeUserRepository();
            repo.AddUser(new User { Username = "far", PasswordHash = "123", Role = "Staff" });

            var service = new AuthService(repo);

            var result = service.Register("far", "456", "Public");

            Assert.That(result, Is.False);
        }

        [Test]
        public void Login_Should_Return_User_When_Details_Are_Correct()
        {
            var repo = new FakeUserRepository();
            repo.AddUser(new User { Username = "far", PasswordHash = "123", Role = "Staff" });

            var service = new AuthService(repo);

            var user = service.Login("far", "123");

            Assert.That(user, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo("far"));
        }

        [Test]
        public void Login_Should_Return_Null_When_Password_Is_Wrong()
        {
            var repo = new FakeUserRepository();
            repo.AddUser(new User { Username = "far", PasswordHash = "123", Role = "Staff" });

            var service = new AuthService(repo);

            var user = service.Login("far", "999");

            Assert.That(user, Is.Null);
        }

        [Test]
        public void Login_Should_Return_Null_When_User_Does_Not_Exist()
        {
            var repo = new FakeUserRepository();
            var service = new AuthService(repo);

            var user = service.Login("unknown", "123");

            Assert.That(user, Is.Null);
        }
    }
}