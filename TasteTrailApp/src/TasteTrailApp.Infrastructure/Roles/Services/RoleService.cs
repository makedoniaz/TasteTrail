using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Core.Roles.Services;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Infrastructure.Roles.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    
    private readonly UserManager<User> _userManager;

    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
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

    public async Task<IdentityResult> AssignRoleToUserAsync(string userId, UserRoles role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var roleName = role.ToString();

        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = $"User with ID {userId} not found." });

        if (!await _roleManager.RoleExistsAsync(roleName))
            return IdentityResult.Failed(new IdentityError { Description = $"Role {roleName} not found." });

        return await _userManager.AddToRoleAsync(user, roleName);
    
    }

    public async Task<IdentityResult> RemoveRoleFromUserAsync(string userId, UserRoles role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var roleName = role.ToString();

         if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = $"User with ID {userId} not found." });

        if (!await _roleManager.RoleExistsAsync(roleName))
            return IdentityResult.Failed(new IdentityError { Description = $"Role {roleName} not found." });


        return await _userManager.RemoveFromRoleAsync(user, roleName);
    }
}