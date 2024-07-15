using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;
using TasteTrailApp.Core.Menu.Repositories;
using TasteTrailApp.Core.Menu.Services;

namespace TasteTrailApp.Infrastructure.Menu.Services
{
    public class MenuSerivce : IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuSerivce(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task CreateAsync(MenuModel menu)
        {
            var changesCount = await this.menuRepository.CreateAsync(menu);

            if (changesCount == 0)
                throw new InvalidOperationException("Menu creation didn't apply!");
        }

        public async Task DeleteByIdAsync(int id)
        {
            var changesCount = await this.menuRepository.DeleteByIdAsync(id);

            if (changesCount == 0)
                throw new InvalidOperationException("Menu delete didn't apply!");
        }

        public async Task<List<MenuModel>> GetAllAsync()
        {
            var result = await this.menuRepository.GetAllAsync();
            return result;
        }

        public async Task<IEnumerable<MenuModel>> GetAllMenusByVenueId(int venueId)
        {
            var menus = await menuRepository.GetAllByVenueId(venueId);
            return menus;
        }

        public async Task<MenuModel> GetByIdAsync(int id)
        {
            var result = await this.menuRepository.GetByIdAsync(id);
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public async Task PutAsync(MenuModel menu)
        {
            var changesCount = await this.menuRepository.PutAsync(menu);

            if (changesCount == 0)
                throw new InvalidOperationException("Menu put didn't apply!");
        }
    }
}
