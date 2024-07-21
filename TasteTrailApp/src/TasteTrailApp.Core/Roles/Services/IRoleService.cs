using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Roles.Enums;

namespace TasteTrailApp.Core.Roles.Services;

public interface IRoleService
{
    Task<IdentityResult> CreateRoleAsync(UserRoles role);

    Task<IdentityResult> DeleteRoleAsync(UserRoles role);

    Task SetupRolesAsync();
}
