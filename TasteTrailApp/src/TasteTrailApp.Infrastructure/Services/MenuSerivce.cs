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

        public Task<List<Menu>?> GetAllAsync()
        {
            return this.menuRepository.GetAllAsync();
        }

        public Task<Menu?> GetByIdAsync(int id)
        {
            return this.menuRepository.GetByIdAsync(id);
        }

        public Task<int> PutAsync(Menu entity)
        {
            return this.menuRepository.PutAsync(entity);
        }
    }
}
