using System.Threading.Tasks;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface IBookApiService
    {
        Task<BookApiResult> SearchBookAsync(string searchTerm);
    }
}