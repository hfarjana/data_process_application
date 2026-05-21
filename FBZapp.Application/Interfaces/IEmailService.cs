using System.Threading.Tasks;

namespace FBZapp.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendComicSavedEmailAsync(string userEmail, string comicTitle);

        Task SendComicFlaggedEmailAsync(string adminEmail, string comicTitle);
    }
}
