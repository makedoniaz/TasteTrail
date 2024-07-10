using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IMenuItemRepository : IGetByCountAsync<MenuItem>, IGetByIdAsync<MenuItem, int>,
ICreateAsync<MenuItem>, IDeleteByIdAsync<int>, IPutAsync<MenuItem> 
{
    Task<IEnumerable<MenuItem>> GetAllByMenuId(int menuId);
}
