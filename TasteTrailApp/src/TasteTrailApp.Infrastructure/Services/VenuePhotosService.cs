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

        public async Task<int> CreateAsync(VenuePhotos entity)
        {
            return await this.venuePhotosRepository.CreateAsync(entity);
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            return await this.venuePhotosRepository.DeleteByIdAsync(id);
        }

        public async Task<List<VenuePhotos>> GetAllAsync()
        {
            var result = await this.venuePhotosRepository.GetAllAsync();
            return result;
        }

        public async Task<int> PutAsync(VenuePhotos entity)
        {
            return await this.venuePhotosRepository.PutAsync(entity);
        }
    }
}
