using TasteTrailApp.Core.VenuesPhotos.Repositories;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Core.VenuesPhotos.Models;

namespace TasteTrailApp.Infrastructure.VenuesPhotos.Repositories;

public class VenuePhotosEFCoreRepository : IVenuePhotosRepository
{
    private readonly TasteTrailDbContext context;

    public VenuePhotosEFCoreRepository(TasteTrailDbContext context)
    {
        this.context = context;
    }

    public async Task<int> CreateAsync(VenuePhotos entity)
    {
        await context.VenuePhotos.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var photo = await context.VenuePhotos.FindAsync(id);
        if (photo != null)
        {
            context.VenuePhotos.Remove(photo);
            return await context.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<List<VenuePhotos>> GetAllAsync()
    {
        return await context.VenuePhotos.ToListAsync();
    }

    public async Task<int> PutAsync(VenuePhotos entity)
    {
        context.VenuePhotos.Update(entity);
        return await context.SaveChangesAsync();
    }
}

