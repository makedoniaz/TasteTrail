using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IVenuePhotosService
    {
        Task<int> CreateAsync(VenuePhotos entity);
        Task<List<VenuePhotos>> GetAllAsync();
        Task<int> DeleteByIdAsync(int id);
        Task<int> PutAsync(VenuePhotos entity);
    }
}
