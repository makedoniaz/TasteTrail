using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Infrastructure.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }

        public async Task<int> CreateAsync(MenuItem entity)
        {
            return await this.menuItemRepository.CreateAsync(entity);
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            return await this.menuItemRepository.DeleteByIdAsync(id);
        }

        public async Task<List<MenuItem>> GetByCountAsync(int count)
        {
            var result = await this.menuItemRepository.GetByCountAsync(count);
            return result;
        }

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            var result = await this.menuItemRepository.GetByIdAsync(id);
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public async Task<int> PutAsync(MenuItem entity)
        {
            return await this.menuItemRepository.PutAsync(entity);
        }
    }
}
