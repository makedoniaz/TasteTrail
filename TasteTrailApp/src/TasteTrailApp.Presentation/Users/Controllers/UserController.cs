using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Roles.Services;
using TasteTrailApp.Core.Users.Services;
using TasteTrailApp.Presentation.Common.ViewModels;

namespace TasteTrailApp.Presentation.Users.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    private readonly IRoleService _roleService;

    public UserController(IUserService userService, IRoleService roleService)
    {
        this._userService = userService;
        this._roleService = roleService;
    }

    [HttpGet]
    [Route("Json/{id}")]
    public async Task<IActionResult> Json(string id)
    {
        var user = await this._userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return Json(new { id = user.Id, name = user.UserName, email = user.Email });
    }

    [HttpPut]
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
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        return BadRequest(ModelState);
    }
}