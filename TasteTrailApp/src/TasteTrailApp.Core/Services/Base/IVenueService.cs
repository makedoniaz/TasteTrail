using System.Security.Cryptography;
using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IVenueService
    {
        Task CreateAsync(Venue entity);

        Task<List<Venue>> GetByCountAsync(int count);

        Task<Venue> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(Venue entity);
    }
}
