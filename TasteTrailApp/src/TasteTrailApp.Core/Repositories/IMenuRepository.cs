using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IMenuRepository : IGetAllAsync<Menu>, IGetByIdAsync<Menu, int>,
ICreateAsync<Menu>, IDeleteByIdAsync<Menu>, IPutAsync<Menu> 
{
    
}
