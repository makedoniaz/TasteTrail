using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IUserRepository : IGetByCountAsync<User>, IGetByIdAsync<User, int>,
ICreateAsync<User>, IPutAsync<User>
{
    
}
