using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Roles.Services;
using TasteTrailApp.Core.Users.Services;
using TasteTrailApp.Core.Venues.Services;
using TasteTrailApp.Presentation.Common.ViewModels;

namespace TasteTrailApp.Presentation.Common.Controllers;

[Route("[controller]")]
public class AdminPanelController : Controller
{
    private readonly IUserService _userService;
    private readonly IVenueService _venueService;
    private readonly IRoleService roleService;

    public AdminPanelController(IUserService userService, IVenueService venueService, IRoleService roleService)
    {
        this._userService = userService;
        this._venueService = venueService;
        this.roleService = roleService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Dashboard()
    {
        var users = await this._userService.GetAllAsync();
        int feedbacks = 0;

        // foreach (var user in users)
        // {
        //     if(user.Feedbacks.Count() == 0)
        //     {
        //         continue;
        //     }
        //     feedbacks += user.Feedbacks.Count();
        // }
        var venues = await this._venueService.GetAllAsync();

        var model = new AdminDashboardViewModel
        {
            TotalUsers = users.Count(),
            TotalFeedbacks = feedbacks,
            TotalVenues = venues.Count()
        };

        return View(model);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Index()
    {
        return View();
    }
}
