using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Infrastructure.Services
{
    public class MenuItemMenusService : IMenuItemMenusService
    {
        private readonly IMenuItemMenusRepository menuItemMenusRepository;

        public MenuItemMenusService(IMenuItemMenusRepository menuItemMenusRepository)
        {
            this.menuItemMenusRepository = menuItemMenusRepository;
        }

        public async Task CreateAsync(MenuItemMenus menuItemMenus)
        {
            var changesCount = await this.menuItemMenusRepository.CreateAsync(menuItemMenus);

            if (changesCount == 0)
                throw new InvalidOperationException("MenuItemMenus creation didn't apply!");
        }

        public async Task DeleteByIdAsync(int id)
        {
            var changesCount = await this.menuItemMenusRepository.DeleteByIdAsync(id);

            if (changesCount == 0)
                throw new InvalidOperationException("MenuItemMenus delete didn't apply!");
        }

        public async Task<List<MenuItemMenus>> GetByCountAsync(int count)
        {
            return await this.menuItemMenusRepository.GetByCountAsync(count);;
        }

        public async Task PutAsync(MenuItemMenus menuItemMenus)
        {
            var changesCount = await this.menuItemMenusRepository.PutAsync(menuItemMenus);

            if (changesCount == 0)
                throw new InvalidOperationException("MenuItemMenus put didn't apply!");
        }
    }
}
