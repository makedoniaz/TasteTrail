using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;
using TasteTrailApp.Core.Menu.Repositories;
using TasteTrailApp.Infrastructure.Context;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace TasteTrailApp.Infrastructure.Menu.Repositories
{
    public class MenuEFCoreRepository : IMenuRepository
    {
        private readonly TasteTrailDbContext context;

        public MenuEFCoreRepository(TasteTrailDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> CreateAsync(MenuModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Menus.Add(entity);
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

        public async Task<List<MenuModel>> GetAllAsync()
        {
            return await context.Menus.ToListAsync();
        }

        public async Task<IEnumerable<MenuModel>> GetAllByVenueId(int venueId)
        {
            return await context.Menus
                .Where(item => item.VenueId == venueId)
                .ToListAsync();
        }

        public async Task<MenuModel?> GetByIdAsync(int id)
        {
            return await context.Menus.FindAsync(id);
        }

        public async Task<int> PutAsync(MenuModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}