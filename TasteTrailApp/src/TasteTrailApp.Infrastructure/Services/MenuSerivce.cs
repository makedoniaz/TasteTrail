using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Infrastructure.Services
{
    public class MenuSerivce : IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuSerivce(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<int> CreateAsync(Menu entity)
        {
            return await this.menuRepository.CreateAsync(entity);
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            return await this.menuRepository.DeleteByIdAsync(id);
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            var result = await this.menuRepository.GetAllAsync();
            return result;
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            var result = await this.menuRepository.GetByIdAsync(id);
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public async Task<int> PutAsync(Menu entity)
        {
            return await this.menuRepository.PutAsync(entity);
        }
    }
}
