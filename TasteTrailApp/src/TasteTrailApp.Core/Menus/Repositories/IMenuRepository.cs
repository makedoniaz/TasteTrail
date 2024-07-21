using TasteTrailApp.Core.Common.Repositories.Base;
using TasteTrailApp.Core.Menus.Models;

namespace TasteTrailApp.Core.Menus.Repositories;

public interface IMenuRepository : IGetAllAsync<Menu>, IGetByIdAsync<Menu, int>,
ICreateAsync<Menu>, IDeleteByIdAsync<int>, IPutAsync<Menu> 
{
    Task<IEnumerable<Models.Menu>> GetAllByVenueId(int venueId);
}
