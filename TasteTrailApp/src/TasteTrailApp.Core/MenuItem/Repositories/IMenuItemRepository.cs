using TasteTrailApp.Core.Common.Repositories.Base;

namespace TasteTrailApp.Core.MenuItem.Repositories;

public interface IMenuItemRepository : IGetByCountAsync<Models.MenuItem>, IGetByIdAsync<Models.MenuItem, int>,
ICreateAsync<Models.MenuItem>, IDeleteByIdAsync<int>, IPutAsync<Models.MenuItem> 
{
    Task<IEnumerable<Models.MenuItem>> GetAllByMenuId(int menuId);
}
