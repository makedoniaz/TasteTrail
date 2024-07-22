using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Authentications.Services;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Core.Users.Models;
using TasteTrailApp.Core.Users.Services;
using TasteTrailApp.Infrastructure.Common.Dtos;

namespace TasteTrailApp.Infrastructure.Authentications.Services;

public class IdentityAuthService : IIdentityAuthService
{
    private readonly SignInManager<User> _signInManager;

    private readonly IUserService _userService;

    public IdentityAuthService(SignInManager<User> signInManager, IUserService userService)
    {
        _signInManager = signInManager;
        _userService = userService;
    }

    public async Task<IdentityResult> RegisterAsync(User user, string password) {
        return await _userService.CreateUserAsync(user, password);
    }

    public async Task SignInAsync(string username, string password, bool rememberMe)
    {
        var user = await _userService.GetUserByUsernameAsync(username);

        if(user == null)
            throw new InvalidCredentialException("User not found!");

        var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

        if (user.IsBanned)
            throw new AuthenticationFailureException("Account is banned!");

        if (!result.Succeeded)
            throw new AuthenticationFailureException("Invalid credentials!");

        await _userService.AddUserClaimAsync(user, new Claim("IsMuted", user.IsMuted.ToString()));
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}