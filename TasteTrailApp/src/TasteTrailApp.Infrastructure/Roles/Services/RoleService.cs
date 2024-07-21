using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Core.Roles.Services;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Infrastructure.Roles.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
    }

    public async Task<IdentityResult> CreateRoleAsync(UserRoles role)
    {
        var roleName = role.ToString();

        if (!await _roleManager.RoleExistsAsync(roleName))
            return await _roleManager.CreateAsync(new IdentityRole(roleName));

        return IdentityResult.Failed(new IdentityError { Description = $"Role {roleName} already exists." });
    }

    public async Task<IdentityResult> DeleteRoleAsync(UserRoles role)
    {
        var roleName = role.ToString();
        var roleToDelete = await _roleManager.FindByNameAsync(roleName);

        if (roleToDelete == null)
            return IdentityResult.Failed(new IdentityError { Description = $"Role {roleName} not found." });

        return await _roleManager.DeleteAsync(roleToDelete);
    }
}