using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TasteTrailApp.Presentation.Common.Dtos;
using TasteTrailApp.Core.Authentications.Services;
using TasteTrailApp.Core.Users.Services;
using TasteTrailApp.Core.Users.Models;
using TasteTrailApp.Core.Roles.Enums;

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
            var result = await this.identityAuthService.SignInAsync(loginDto.Username, loginDto.Password, true);

            if (!result.Succeeded)
            {
                base.TempData["error"] = "Incorrect login or password!";
                return base.RedirectToRoute("LoginView");
            }

            return base.RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
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
            var result = await userService.CreateUserAsync(user, registrationDto.Password);

            if (!result.Succeeded)
            {
                base.TempData["error"] = result.Succeeded ? "" : string.Join("\n", result.Errors.Select(error => error.Description));
                return RedirectToAction("RegistrationView");
            }

            await userService.AssignRoleToUserAsync(registrationDto.Name, roleToAssign);

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
