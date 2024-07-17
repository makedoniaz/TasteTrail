using TasteTrailApp.Core.VenuesPhotos.Models;

namespace TasteTrailApp.Core.VenuesPhotos.Services;

public interface IVenuePhotosService
{
    Task CreateAsync(VenuePhotos entity);

    Task<List<VenuePhotos>> GetAllAsync();

    Task DeleteByIdAsync(int id);
    
    Task PutAsync(VenuePhotos entity);
}

