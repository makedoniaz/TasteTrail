using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Roles.Services;
using TasteTrailApp.Core.Users.Services;

namespace TasteTrailApp.Presentation.Common.Controllers
{
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

        public IActionResult Index()
        {
            return View();
        }
    }
}