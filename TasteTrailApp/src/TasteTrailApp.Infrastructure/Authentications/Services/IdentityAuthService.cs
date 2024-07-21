using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Authentications.Services;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Infrastructure.Authentications.Services;

public class IdentityAuthService : IIdentityAuthService
{
    private readonly SignInManager<User> _signInManager;

    public IdentityAuthService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<SignInResult> SignInAsync(string username, string password, bool rememberMe)
    {
        return await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}