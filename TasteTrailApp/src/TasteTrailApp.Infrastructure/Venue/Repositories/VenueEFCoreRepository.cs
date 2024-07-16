using VenueModel = TasteTrailApp.Core.Venue.Models.Venue;
using TasteTrailApp.Core.Venue.Repositories;
using TasteTrailApp.Infrastructure.Context;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace TasteTrailApp.Infrastructure.Venue.Repositories
{
    public class VenueEFCoreRepository : IVenueRepository
    {
        private readonly TasteTrailDbContext context;

        public VenueEFCoreRepository(TasteTrailDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(VenueModel entity)
        {
            await context.Venues.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CreateAsyncReturningId(VenueModel venue)
        {
            var result = await context.Venues.AddAsync(venue);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var venue = await context.Venues.FindAsync(id);
            if (venue != null)
            {
                context.Venues.Remove(venue);
                return await context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<VenueModel>> GetByCountAsync(int count)
        {
            return await context.Venues.Take(count).ToListAsync();
        }

        public async Task<VenueModel?> GetByIdAsync(int id)
        {
            return await context.Venues.FindAsync(id);
        }

        public async Task PatchLogoUrlPathAsync(VenueModel venue, string logoUrlPath)
        {
            venue.LogoUrlPath = logoUrlPath;
            context.Venues.Update(venue);
            await context.SaveChangesAsync();
        }

        public async Task<int> PutAsync(VenueModel entity)
        {
            context.Venues.Update(entity);
            return await context.SaveChangesAsync();
        }
    }
}
