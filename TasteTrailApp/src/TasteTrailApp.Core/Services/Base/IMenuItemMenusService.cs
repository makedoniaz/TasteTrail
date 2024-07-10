using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IMenuItemMenusService
    {
        Task CreateAsync(MenuItemMenus entity);

        Task<List<MenuItemMenus>> GetByCountAsync(int count);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(MenuItemMenus entity);
    }
}
