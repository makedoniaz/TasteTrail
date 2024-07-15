using Microsoft.AspNetCore.Http;

namespace TasteTrailApp.Core.Venue.Services
{
    public interface IVenueService
    {
        Task CreateAsync(Models.Venue venue, IFormFile? logo);

        Task<List<Models.Venue>> GetByCountAsync(int count);

        Task<Models.Venue> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(Models.Venue entity);

        Task SetVenueLogo(Models.Venue venue, IFormFile? logo);

        Task DeleteVenueLogoAsync(int venueId);

        Task<int> CreateAsyncRerturningId(Models.Venue venue);
    }
}
