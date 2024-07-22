using System.Security.Claims;
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
    public async Task<IList<string>> GetRoleByUsernameAsync(string username)
    {
        var user  = await GetUserByUsernameAsync(username: username);
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return _userManager.Users.ToList();
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

    public async Task<bool> HasRegisteredUsers()
    {
        return await _userManager.Users.AnyAsync();
    }

    public async Task ToggleMuteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            throw new Exception("User not found!");

        user.IsMuted = !user.IsMuted;
        await _userManager.UpdateAsync(user);

        var claims = await _userManager.GetClaimsAsync(user);
        var isMutedClaim = claims.FirstOrDefault(c => c.Type == "IsMuted");

        if (isMutedClaim == null)
            throw new Exception("Muted claim doesn't exist!");

        await _userManager.ReplaceClaimAsync(user, isMutedClaim, new Claim("IsMuted", user.IsMuted.ToString()));
    }

    public async Task ToggleBanUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            throw new Exception("User not found!");

        user.IsBanned = !user.IsBanned;
        await _userManager.UpdateAsync(user);
    }

    public async Task<IList<Claim>> GetUserClaimsAsync(User user)
    {
        return await _userManager.GetClaimsAsync(user);
    }

    public async Task AddUserClaimAsync(User user, Claim claim)
    {
        var existingClaim = (await _userManager.GetClaimsAsync(user))
                .FirstOrDefault(c => c.Type == claim.Type);

        if (existingClaim is null)
            await _userManager.AddClaimAsync(user, claim);
    }
}
