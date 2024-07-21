using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Core.Users.Services;

public interface IUserService
{
    Task<IdentityResult> CreateUserAsync(User user, string password);

    Task<User> GetUserByIdAsync(string userId);

    Task<IdentityResult> UpdateUserAsync(User user);

    Task<IdentityResult> DeleteUserAsync(string userId);
}
