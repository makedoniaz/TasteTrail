using TasteTrailApp.Core.MenuItems.Models;

namespace TasteTrailApp.Core.MenuItems.Services;

public interface IMenuItemService
{
    Task CreateAsync(MenuItem entity);

    Task<List<MenuItem>> GetByCountAsync(int count);

    Task<MenuItem> GetByIdAsync(int id);

    Task DeleteByIdAsync(int id);
    
    Task PutAsync(MenuItem entity);

    Task<IEnumerable<MenuItem>> GetAllMenuItemsByMenuId(int menuId);
}

