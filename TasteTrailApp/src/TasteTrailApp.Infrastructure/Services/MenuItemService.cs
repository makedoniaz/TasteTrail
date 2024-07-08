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

        public Task<int> CreateAsync(MenuItem entity)
        {
            return this.menuItemRepository.CreateAsync(entity);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            return this.menuItemRepository.DeleteByIdAsync(id);
        }

        public Task<List<MenuItem>?> GetByCountAsync(int count)
        {
            return this.menuItemRepository.GetByCountAsync(count);
        }

        public Task<MenuItem?> GetByIdAsync(int id)
        {
            return this.menuItemRepository.GetByIdAsync(id);
        }

        public Task<int> PutAsync(MenuItem entity)
        {
            return this.menuItemRepository.PutAsync(entity);
        }
    }
}
