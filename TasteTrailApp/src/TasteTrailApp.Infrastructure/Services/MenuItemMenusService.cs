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

        public Task<int> CreateAsync(MenuItemMenus entity)
        {
            return this.menuItemMenusRepository.CreateAsync(entity);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            return this.menuItemMenusRepository.DeleteByIdAsync(id);
        }

        public Task<List<MenuItemMenus>> GetByCountAsync(int count)
        {
            var result = this.menuItemMenusRepository.GetByCountAsync(count);
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public Task<int> PutAsync(MenuItemMenus entity)
        {
            return this.menuItemMenusRepository.PutAsync(entity);
        }
    }
}
