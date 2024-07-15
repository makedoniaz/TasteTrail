using VenuePhotosModel = TasteTrailApp.Core.VenuePhotos.Models.VenuePhotos;
using TasteTrailApp.Core.VenuePhotos.Repositories;
using TasteTrailApp.Core.VenuePhotos.Services;

namespace TasteTrailApp.Infrastructure.VenuePhotos.Services
{
    public class VenuePhotosService : IVenuePhotosService
    {
        private readonly IVenuePhotosRepository venuePhotosRepository;

        public VenuePhotosService(IVenuePhotosRepository venuePhotosRepository)
        {
            this.venuePhotosRepository = venuePhotosRepository;
        }

        public async Task CreateAsync(VenuePhotosModel venuePhotos)
        {
            var changesCount = await this.venuePhotosRepository.CreateAsync(venuePhotos);

            if (changesCount == 0)
                throw new InvalidOperationException("VenuePhotos create didn't apply!");
        }

        public async Task DeleteByIdAsync(int id)
        {
            var changesCount = await this.venuePhotosRepository.DeleteByIdAsync(id);

            if (changesCount == 0)
                throw new InvalidOperationException("VenuePhotos delete didn't apply!");
        }

        public async Task<List<VenuePhotosModel>> GetAllAsync()
        {
            var result = await this.venuePhotosRepository.GetAllAsync();
            return result;
        }

        public async Task PutAsync(VenuePhotosModel venuePhotos)
        {
            var changesCount = await this.venuePhotosRepository.PutAsync(venuePhotos);

            if (changesCount == 0)
                throw new InvalidOperationException("VenuePhotos put didn't apply!");
        }
    }
}
