using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Roles.Enums;
using TasteTrailApp.Core.Roles.Services;
using TasteTrailApp.Core.Users.Services;
using TasteTrailApp.Presentation.Common.ViewModels;
using TasteTrailApp.Core.Authentications.Services;

namespace TasteTrailApp.Presentation.Users.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IIdentityAuthService _identityAuthService;

    public UserController(IIdentityAuthService identityAuthService, IUserService userService)
    {
        this._identityAuthService = identityAuthService;
        this._userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var users = await this._userService.GetAllAsync();

        var userViewModels = new List<UserViewModel>();

        foreach (var user in users)
        {
            var role = await this._userService.GetRoleByUsernameAsync(user.UserName!);

            var userViewModel = new UserViewModel
            {
                User = user,
                Role = role.First()
            };

            userViewModels.Add(userViewModel);
        }

        return View(userViewModels);
    }


    [HttpGet]
    [Route("Json/{id}")]
    public async Task<IActionResult> Json(string id)
    {
        var user = await this._userService.GetUserByIdAsync(id);
        var role = await this._userService.GetRoleByUsernameAsync(user.UserName!);

        if (user == null)
        {
            return NotFound();
        }

        return Json(new { id = user.Id, name = user.UserName, email = user.Email, role = role });
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.GetUserByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.Name;
            user.Email = model.Email;

            var result = await _userService.UpdateUserAsync(user);
            if (result.Succeeded)
            {
                await this._identityAuthService.SignOutAsync();
                return base.Ok();
        
            }

            return BadRequest(result.Errors);
        }

        return BadRequest(ModelState);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Route("[action]", Name = "AssignRole")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRole([FromQuery] string userId, [FromQuery] UserRoles role)
    {
        try
        {
            await _userService.AssignRoleToUserAsync(userId, role);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); // Возвращаем ошибку 400 при исключении
        }
    }

    [HttpPost]
    [Route("[action]", Name = "RemoveUserRole")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveRole([FromQuery] string username, [FromQuery] UserRoles role)
    {
        try
        {
            await _userService.RemoveRoleFromUserAsync(username, role);
        }
        catch (Exception ex)
        {
            BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPost]
    [Route("[action]/{userId}", Name = "ToggleMute")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleMute(string userId)
    {
        try
        {
            await _userService.ToggleMuteUser(userId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Route("[action]/{userId}", Name = "ToggleBanUser")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleBan(string userId)
    {
        try
        {
            await _userService.ToggleBanUser(userId);
        }
        catch (Exception ex)
        {
            BadRequest(ex.Message);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("/[controller]/{userId}")]
    public async Task<IActionResult> UserInfo(string userId)
    {
        var user = await this._userService.GetUserByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }
}