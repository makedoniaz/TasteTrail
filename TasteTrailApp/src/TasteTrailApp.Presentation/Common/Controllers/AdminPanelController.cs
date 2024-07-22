using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Roles.Services;
using TasteTrailApp.Core.Users.Services;
using TasteTrailApp.Presentation.Common.ViewModels;

namespace TasteTrailApp.Presentation.Common.Controllers;

[Route("[controller]")]
public class AdminPanelController : Controller
{
    private readonly IUserService userService;

    private readonly IRoleService roleService;

    public AdminPanelController(IUserService userService, IRoleService roleService)
    {
        this.userService = userService;
        this.roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        var model = new AdminDashboardViewModel
        {
            TotalUsers = 0,
            TotalFeedbacks = 0,
            TotalVenues = 0
        };

        return View(model);
    }
}
