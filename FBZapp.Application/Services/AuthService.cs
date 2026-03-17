using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Register(string username, string password, string role)
        {
            var existingUser = _userRepository.GetByUsername(username);

            if (existingUser != null)
            {
                return false;
            }

            var user = new User
            {
                Username = username,
                PasswordHash = password,
                Role = role
            };

            _userRepository.AddUser(user);
            return true;
        }

        public User Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                return null;
            }

            if (user.PasswordHash != password)
            {
                return null;
            }

            return user;
        }
    }
}
