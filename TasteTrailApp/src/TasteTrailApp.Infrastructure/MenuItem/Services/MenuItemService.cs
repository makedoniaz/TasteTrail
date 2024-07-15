using MenuItemModel = TasteTrailApp.Core.MenuItem.Models.MenuItem;
using TasteTrailApp.Core.MenuItem.Repositories;
using TasteTrailApp.Core.MenuItem.Services;

namespace TasteTrailApp.Infrastructure.MenuItem.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }

        public async Task CreateAsync(MenuItemModel menuItem)
        {
            var changesCount = await this.menuItemRepository.CreateAsync(menuItem);

            if (changesCount == 0)
                throw new InvalidOperationException("MenuItem creation didn't apply!");
        }

        public async Task DeleteByIdAsync(int id)
        {
            var changesCount = await this.menuItemRepository.DeleteByIdAsync(id);

            if (changesCount == 0)
                throw new InvalidOperationException("MenuItem delete didn't apply!");
        }

        public async Task<IEnumerable<MenuItemModel>> GetAllMenuItemsByMenuId(int menuId)
        {
            var result = await this.menuItemRepository.GetAllByMenuId(menuId);
            return result;
        }

        public async Task<List<MenuItemModel>> GetByCountAsync(int count)
        {
            var result = await this.menuItemRepository.GetByCountAsync(count);
            return result;
        }

        public async Task<MenuItemModel> GetByIdAsync(int id)
        {
            var result = await this.menuItemRepository.GetByIdAsync(id);
            ArgumentNullException.ThrowIfNull(result);
            
            return result;
        }

        public async Task PutAsync(MenuItemModel menuItem)
        {
            var changesCount = await this.menuItemRepository.PutAsync(menuItem);

            if (changesCount == 0)
                throw new InvalidOperationException("MenuItem put didn't apply!");
        }
    }
}
