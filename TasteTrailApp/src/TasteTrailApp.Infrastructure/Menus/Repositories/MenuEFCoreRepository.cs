using TasteTrailApp.Core.Menus.Repositories;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Core.Menus.Models;

namespace TasteTrailApp.Infrastructure.Menus.Repositories;

public class MenuEFCoreRepository : IMenuRepository
{
    private readonly TasteTrailDbContext context;

    public MenuEFCoreRepository(TasteTrailDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> CreateAsync(Menu entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        context.Menus.Add(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await context.Menus.FindAsync(id);

        if (entity == null)
            throw new ArgumentException($"Entity with id {id} not found.", nameof(id));

        context.Menus.Remove(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await context.Menus.ToListAsync();
    }

    public async Task<IEnumerable<Menu>> GetAllByVenueId(int venueId)
    {
        return await context.Menus
            .Where(item => item.VenueId == venueId)
            .ToListAsync();
    }

    public async Task<Menu?> GetByIdAsync(int id)
    {
        return await context.Menus.FindAsync(id);
    }

    public async Task<int> PutAsync(Menu entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return entity.Id;
    }
}
