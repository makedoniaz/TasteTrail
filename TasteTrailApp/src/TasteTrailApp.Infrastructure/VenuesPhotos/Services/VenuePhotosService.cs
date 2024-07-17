using TasteTrailApp.Core.VenuesPhotos.Models;
using TasteTrailApp.Core.VenuesPhotos.Repositories;
using TasteTrailApp.Core.VenuesPhotos.Services;

namespace TasteTrailApp.Infrastructure.VenuesPhotos.Services;

public class VenuePhotosService : IVenuePhotosService
{
    private readonly IVenuePhotosRepository venuePhotosRepository;

    public VenuePhotosService(IVenuePhotosRepository venuePhotosRepository)
    {
        this.venuePhotosRepository = venuePhotosRepository;
    }

    public async Task CreateAsync(VenuePhotos venuePhotos)
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

    public async Task<List<VenuePhotos>> GetAllAsync()
    {
        var result = await this.venuePhotosRepository.GetAllAsync();
        return result;
    }

    public async Task PutAsync(VenuePhotos venuePhotos)
    {
        var changesCount = await this.venuePhotosRepository.PutAsync(venuePhotos);

        if (changesCount == 0)
            throw new InvalidOperationException("VenuePhotos put didn't apply!");
    }
}

