using Microsoft.AspNetCore.Http;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Core.Venues.Services;

public interface IVenueService
{
    Task CreateAsync(Venue venue, IFormFile? logo);

    Task<List<Venue>> GetByCountAsync(int count);

    Task<Venue> GetByIdAsync(int id);

    Task DeleteByIdAsync(int id);
    
    Task PutAsync(Venue entity);

    Task SetVenueLogo(Venue venue, IFormFile? logo);

    Task DeleteVenueLogoAsync(int venueId);

    Task<int> CreateAsyncRerturningId(Venue venue);
}

