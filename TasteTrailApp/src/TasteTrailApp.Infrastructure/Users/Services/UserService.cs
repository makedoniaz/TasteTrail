using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Users.Exceptions;
using TasteTrailApp.Core.Users.Models;
using TasteTrailApp.Core.Users.Services;

namespace TasteTrailApp.Infrastructure.Users.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
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
}
