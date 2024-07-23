using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Core.Users.Services;

public interface IUserService
{
    Task<IdentityResult> CreateUserAsync(User user, string password);

    Task<IEnumerable<User>> GetAllAsync();
    Task<IList<string>> GetRoleByUsernameAsync(string username);
    Task<User> GetUserByIdAsync(string userId);

    Task<User> GetUserByUsernameAsync(string username);

    Task<IdentityResult> UpdateUserAsync(User user);

    Task<IdentityResult> DeleteUserAsync(string userId);

    Task<IdentityResult> AssignRoleToUserAsync(string userId, UserRoles role);

    Task<IdentityResult> RemoveRoleFromUserAsync(string userId, UserRoles role);

    Task AddUserClaimAsync(User user, Claim claim);

    Task ToggleBanUser(string userId);

    Task ToggleMuteUser(string userId);

    Task<bool> HasRegisteredUsers();
}
