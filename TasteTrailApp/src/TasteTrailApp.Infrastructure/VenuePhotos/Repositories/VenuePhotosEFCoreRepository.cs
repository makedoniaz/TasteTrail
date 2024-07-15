using VenuePhotosModel = TasteTrailApp.Core.VenuePhotos.Models.VenuePhotos;
using TasteTrailApp.Core.VenuePhotos.Repositories;
using TasteTrailApp.Infrastructure.Context;
using TasteTrailApp.Core.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace TasteTrailApp.Infrastructure.VenuePhotos.Repositories
{
    public class VenuePhotosEFCoreRepository : IVenuePhotosRepository
    {
        private readonly TasteTrailDbContext context;

        public VenuePhotosEFCoreRepository(TasteTrailDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(VenuePhotosModel entity)
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

        public async Task<List<VenuePhotosModel>> GetAllAsync()
        {
            return await context.VenuePhotos.ToListAsync();
        }

        public async Task<int> PutAsync(VenuePhotosModel entity)
        {
            context.VenuePhotos.Update(entity);
            return await context.SaveChangesAsync();
        }
    }
}
