using System.Threading.Tasks;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface IComicApiIntegrationService
    {
        Task EnrichComicWithApiDataAsync(Comic comic);
    }
}
