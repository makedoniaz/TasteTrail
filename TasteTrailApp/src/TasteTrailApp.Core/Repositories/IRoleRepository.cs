using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IRoleRepository : IGetAllAsync<Role>, ICreateAsync<Role>
{
    
}
