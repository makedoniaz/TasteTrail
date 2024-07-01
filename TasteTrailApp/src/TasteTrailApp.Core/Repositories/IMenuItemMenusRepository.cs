using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IMenuItemMenusRepository : IGetByCountAsync<MenuItemMenus>, ICreateAsync<MenuItemMenus>,
IDeleteByIdAsync<MenuItemMenus>, IPutAsync<MenuItemMenus> 
{
    
}
