using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Core.Users.Exceptions;
using TasteTrailApp.Core.Users.Models;
using TasteTrailApp.Core.Users.Services;

namespace TasteTrailApp.Infrastructure.Users.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IdentityResult> CreateUserAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId) ?? throw new UserNotFoundException(userId);
        
        return user;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username) ?? throw new UserNotFoundException(username);

        return user;
    }   

    public async Task<IdentityResult> UpdateUserAsync(User user)
    {
        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = $"User with ID {userId} not found." });

        return await _userManager.DeleteAsync(user);
    }

    public async Task<IdentityResult> AssignRoleToUserAsync(string username, UserRoles role)
    {
        var user = await _userManager.FindByNameAsync(username);
        var roleName = role.ToString();

        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = $"User with name {username} not found." });

        if (!await _roleManager.RoleExistsAsync(roleName))
            return IdentityResult.Failed(new IdentityError { Description = $"Role {roleName} not found." });

        return await _userManager.AddToRoleAsync(user, roleName);
    }

    public async Task<IdentityResult> RemoveRoleFromUserAsync(string username, UserRoles role)
    {
        var user = await _userManager.FindByNameAsync(username);
        var roleName = role.ToString();

         if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = $"User with name {username} not found." });

        if (!await _roleManager.RoleExistsAsync(roleName))
            return IdentityResult.Failed(new IdentityError { Description = $"Role {roleName} not found." });

        return await _userManager.RemoveFromRoleAsync(user, roleName);
    }

    public async Task<bool> HasRegisteredUsers() {
        return await _userManager.Users.AnyAsync();
    }
}
