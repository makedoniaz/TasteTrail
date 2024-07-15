namespace TasteTrailApp.Core.VenuePhotos.Services
{
    public interface IVenuePhotosService
    {
        Task CreateAsync(Models.VenuePhotos entity);

        Task<List<Models.VenuePhotos>> GetAllAsync();

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(Models.VenuePhotos entity);
    }
}
