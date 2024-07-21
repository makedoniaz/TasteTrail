using TasteTrailApp.Core.MenuItems.Repositories;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Core.MenuItems.Models;

namespace TasteTrailApp.Infrastructure.MenuItems.Repositories;

public class MenuItemEFCoreRepository : IMenuItemRepository
{
    private readonly TasteTrailDbContext context;

    public MenuItemEFCoreRepository(TasteTrailDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> CreateAsync(MenuItem entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        context.MenuItems.Add(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await context.MenuItems.FindAsync(id);
        if (entity == null)
            throw new ArgumentException($"Entity with id {id} not found.", nameof(id));

        context.MenuItems.Remove(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MenuItem>> GetAllByMenuId(int menuId)
    {
        return await context.MenuItems
            .Where(item => item.MenuId == menuId)
            .ToListAsync();
    }

    public async Task<List<MenuItem>> GetByCountAsync(int count)
    {
        return await context.MenuItems
            .Take(count)
            .ToListAsync();
    }

    public async Task<MenuItem?> GetByIdAsync(int id)
    {
        return await context.MenuItems.FindAsync(id);
    }

    public async Task<int> PutAsync(MenuItem entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return entity.Id;
    }
}

