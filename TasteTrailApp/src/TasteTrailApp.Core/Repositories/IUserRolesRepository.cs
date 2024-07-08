using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IUserRolesRepository : IGetByCountAsync<UserRoles>, ICreateAsync<UserRoles>,
IDeleteByIdAsync<int>, IPutAsync<UserRoles>
{
    
}
