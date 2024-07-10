using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IVenuePhotosService
    {
        Task CreateAsync(VenuePhotos entity);

        Task<List<VenuePhotos>> GetAllAsync();

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(VenuePhotos entity);
    }
}
