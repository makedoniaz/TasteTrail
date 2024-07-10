using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IMenuItemMenusService
    {
        Task<int> CreateAsync(MenuItemMenus entity);
        Task<List<MenuItemMenus>> GetByCountAsync(int count);
        Task<int> DeleteByIdAsync(int id);
        Task<int> PutAsync(MenuItemMenus entity);
    }
}
