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

        public async Task<int> CreateAsync(MenuItemMenus entity)
        {
            return await this.menuItemMenusRepository.CreateAsync(entity);
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            return await this.menuItemMenusRepository.DeleteByIdAsync(id);
        }

        public async Task<List<MenuItemMenus>> GetByCountAsync(int count)
        {
            var result = await this.menuItemMenusRepository.GetByCountAsync(count);
            return result;
        }

        public async Task<int> PutAsync(MenuItemMenus entity)
        {
            return await this.menuItemMenusRepository.PutAsync(entity);
        }
    }
}
