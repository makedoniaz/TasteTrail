using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TasteTrailApp.Core.Authentications.Services;
using TasteTrailApp.Core.Users.Services;
using TasteTrailApp.Core.Users.Models;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Infrastructure.Common.Dtos;

namespace TasteTrailApp.Presentation.Identities.Controllers;

[Route("[controller]")]
public class AuthenticationController : Controller
{
    private readonly IIdentityAuthService identityAuthService;

    private readonly IUserService userService;

    public AuthenticationController(IIdentityAuthService identityAuthService, IUserService userService)
    {
        this.identityAuthService = identityAuthService;
        this.userService = userService;
    }


    [HttpGet]
    [Route("[action]", Name = "LoginView")]
    public IActionResult Login(string? ReturnUrl)
    {
        var errorMessage = base.TempData["error"];

        ViewBag.ReturnUrl = ReturnUrl;

        if (errorMessage != null)
        {
            base.ModelState.AddModelError("All", errorMessage.ToString()!);
        }
        return base.View();
    }

    [HttpPost]
    [Route("/api/[controller]/[action]", Name = "LoginEndPoint")]
    public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
    {
        try
        {
            await identityAuthService.SignInAsync(loginDto.Username, loginDto.Password, true);
            return base.RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        catch (Exception ex)
        {
            base.TempData["error"] = ex.Message;
            return base.RedirectToRoute("LoginView");
        }
    }

    [HttpGet]
    [Route("[action]", Name = "RegistrationView")]
    public IActionResult Registration()
    {
        if (TempData["error"] != null)
        {
            ModelState.AddModelError("Error", TempData["error"].ToString());
        }
        return base.View();
    }

    [HttpPost]
    [Route("[action]", Name = "RegistrationEndpoint")]
    public async Task<IActionResult> Registration([FromForm] RegistrationDto registrationDto)
    {
        try
        {
            var user = new User()
            {
                Email = registrationDto.Email,
                UserName = registrationDto.Name,
            };

            var roleToAssign = await userService.HasRegisteredUsers() ? UserRoles.User : UserRoles.Admin;
            var result = await identityAuthService.RegisterAsync(user, registrationDto.Password);

            if (!result.Succeeded)
            {
                base.TempData["error"] = result.Succeeded ? "" : string.Join("\n", result.Errors.Select(error => error.Description));
                return RedirectToAction("RegistrationView");
            }

            var registratedUser = await userService.GetUserByUsernameAsync(registrationDto.Name);
            await userService.AssignRoleToUserAsync(registratedUser.Id, roleToAssign);

            return RedirectToRoute("LoginView");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Authorize]
    [Route("[action]", Name = "LogOut")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await this.identityAuthService.SignOutAsync();
            return base.RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Authorize]
    [Route("[action]", Name = "UserInfo")]
    public async Task<IActionResult> UserInfo()
    {
        return View();
    }
}
