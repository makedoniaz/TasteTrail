using TasteTrailApp.Core.Venues.Repositories;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Infrastructure.Venues.Repositories;

public class VenueEFCoreRepository : IVenueRepository
{
    private readonly TasteTrailDbContext context;

    public VenueEFCoreRepository(TasteTrailDbContext context)
    {
        this.context = context;
    }

    public async Task<int> CreateAsync(Venue venue)
    {
        await context.Venues.AddAsync(venue);
        await context.SaveChangesAsync();
        return venue.Id;
    }

    public async Task<int> CreateAsyncReturningId(Venue venue)
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

    public async Task<List<Venue>> GetByCountAsync(int count)
    {
        return await context.Venues.Take(count).ToListAsync();
    }

    public async Task<Venue?> GetByIdAsync(int id)
    {
        return await context.Venues.FindAsync(id);
    }

    public async Task PatchLogoUrlPathAsync(Venue venue, string logoUrlPath)
    {
        venue.LogoUrlPath = logoUrlPath;
        context.Venues.Update(venue);
        await context.SaveChangesAsync();
    }

    public async Task<int> PutAsync(Venue venue)
    {
        context.Venues.Update(venue);
        return await context.SaveChangesAsync();
    }
}

