using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Infrastructure.Services
{
    public class VenuePhotosService : IVenuePhotosService
    {
        private readonly IVenuePhotosRepository venuePhotosRepository;
        public VenuePhotosService(IVenuePhotosRepository venuePhotosRepository)
        {
            this.venuePhotosRepository = venuePhotosRepository;
        }

        public Task<int> CreateAsync(VenuePhotos entity)
        {
            return this.venuePhotosRepository.CreateAsync(entity);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            return this.venuePhotosRepository.DeleteByIdAsync(id);
        }

        public Task<List<VenuePhotos>> GetAllAsync()
        {
            var result = this.venuePhotosRepository.GetAllAsync();
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public Task<int> PutAsync(VenuePhotos entity)
        {
            return this.venuePhotosRepository.PutAsync(entity);
        }
    }
}
