using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void AddUser(User user);
    }
}
