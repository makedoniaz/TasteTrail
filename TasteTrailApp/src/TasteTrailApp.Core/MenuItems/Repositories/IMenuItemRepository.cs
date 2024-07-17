using TasteTrailApp.Core.Common.Repositories.Base;
using TasteTrailApp.Core.MenuItems.Models;

namespace TasteTrailApp.Core.MenuItems.Repositories;

public interface IMenuItemRepository : IGetByCountAsync<MenuItem>, IGetByIdAsync<MenuItem, int>,
ICreateAsync<MenuItem>, IDeleteByIdAsync<int>, IPutAsync<MenuItem> 
{
    Task<IEnumerable<Models.MenuItem>> GetAllByMenuId(int menuId);
}
