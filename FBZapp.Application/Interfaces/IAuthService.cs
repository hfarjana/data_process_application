using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface IAuthService
    {
        bool Register(string username, string password, string role);
        User Login(string username, string password);
    }
}
