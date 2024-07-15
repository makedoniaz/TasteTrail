using TasteTrailApp.Core.Common.Repositories.Base;

namespace TasteTrailApp.Core.Menu.Repositories;

public interface IMenuRepository : IGetAllAsync<Models.Menu>, IGetByIdAsync<Models.Menu, int>,
ICreateAsync<Models.Menu>, IDeleteByIdAsync<int>, IPutAsync<Models.Menu> 
{
    Task<IEnumerable<Models.Menu>> GetAllByVenueId(int venueId);
}
