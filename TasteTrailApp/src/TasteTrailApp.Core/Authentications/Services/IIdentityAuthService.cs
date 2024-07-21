using Microsoft.AspNetCore.Identity;

namespace TasteTrailApp.Core.Authentications.Services;

public interface IIdentityAuthService
{
    Task<SignInResult> SignInAsync(string username, string password, bool rememberMe);
    
    Task SignOutAsync();
}
