using MenuItemModel = TasteTrailApp.Core.MenuItem.Models.MenuItem;
using TasteTrailApp.Core.MenuItem.Repositories;
using TasteTrailApp.Infrastructure.Context;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace TasteTrailApp.Infrastructure.MenuItem.Repositories
{
    public class MenuItemEFCoreRepository : IMenuItemRepository
    {
        private readonly TasteTrailDbContext context;

        public MenuItemEFCoreRepository(TasteTrailDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> CreateAsync(MenuItemModel entity)
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

        public async Task<IEnumerable<MenuItemModel>> GetAllByMenuId(int menuId)
        {
            return await context.MenuItems
                .Where(item => item.MenuId == menuId)
                .ToListAsync();
        }

        public async Task<List<MenuItemModel>> GetByCountAsync(int count)
        {
            return await context.MenuItems
                .Take(count)
                .ToListAsync();
        }

        public async Task<MenuItemModel?> GetByIdAsync(int id)
        {
            return await context.MenuItems.FindAsync(id);
        }

        public async Task<int> PutAsync(MenuItemModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
