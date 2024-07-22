using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Users.Models;

namespace TasteTrailApp.Core.Authentications.Services;

public interface IIdentityAuthService
{
    Task<IdentityResult> RegisterAsync(User user, string password);

    Task SignInAsync(string username, string password, bool rememberMe);
    
    Task SignOutAsync();
}
