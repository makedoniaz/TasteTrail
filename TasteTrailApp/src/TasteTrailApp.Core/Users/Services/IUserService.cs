using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Core.Users.Services;

public interface IUserService
{
    Task<IdentityResult> CreateUserAsync(User user, string password);

    Task<User> GetUserByIdAsync(string userId);

    Task<User> GetUserByUsernameAsync(string username);

    Task<IdentityResult> UpdateUserAsync(User user);

    Task<IdentityResult> DeleteUserAsync(string userId);

    Task<IdentityResult> AssignRoleToUserAsync(string username, UserRoles role);

    Task<IdentityResult> RemoveRoleFromUserAsync(string username, UserRoles role);

    Task<bool> HasRegisteredUsers();
}
