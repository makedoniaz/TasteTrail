using Microsoft.AspNetCore.Identity;

namespace TasteTrailApp.Core.Authentications.Services;

public interface IAuthenticationService
{
    Task<SignInResult> SignInAsync(string username, string password, bool rememberMe);
    
    Task SignOutAsync();
}
