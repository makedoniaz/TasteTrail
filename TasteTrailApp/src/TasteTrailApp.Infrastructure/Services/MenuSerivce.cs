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

        public Task<int> CreateAsync(Menu entity)
        {
            return this.menuRepository.CreateAsync(entity);
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            return this.menuRepository.DeleteByIdAsync(id);
        }

        public Task<List<Menu>> GetAllAsync()
        {
            var result = this.menuRepository.GetAllAsync();
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public Task<Menu> GetByIdAsync(int id)
        {
            var result = this.menuRepository.GetByIdAsync(id);
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public Task<int> PutAsync(Menu entity)
        {
            return this.menuRepository.PutAsync(entity);
        }
    }
}
