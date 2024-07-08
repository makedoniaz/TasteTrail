using System.Security.Cryptography;
using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IVenueService
    {
        Task<int> CreateAsync(Venue entity);
        Task<List<Venue>?> GetByCountAsync(int count);
        Task<Venue?> GetByIdAsync(int id);
        Task<int> DeleteByIdAsync(int id);
        Task<int> PutAsync(Venue entity);
    }
}
