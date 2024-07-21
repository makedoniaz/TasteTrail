using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TasteTrailApp.Presentation.Common.Dtos;
using Microsoft.AspNetCore.Identity;

namespace TasteTrailApp.Presentation.Identities.Controllers
{

    [Route("[controller]")]
    public class IdentityController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        private readonly UserManager<IdentityUser> userManager;
        
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
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
            var user = await this.userManager.FindByEmailAsync(loginDto.Login);

            if (user == null)
            {
                return base.BadRequest("Incorrect email or password!");
            }

            var result = await this.signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);

            base.TempData["error"] = "Incorrect login or password!";

            return result.Succeeded
                ? base.RedirectToAction(actionName: "Index", controllerName: "Home")
                : base.RedirectToAction(actionName: "Login", controllerName: "Identity");

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
            var result = await userManager.CreateAsync(new IdentityUser()
            {

                Email = registrationDto.Email,
                UserName = registrationDto.Name,

            }, registrationDto.Password);

            base.TempData["error"] = result.Succeeded ? "" : string.Join("\n", result.Errors.Select(error => error.Description));

            return result.Succeeded
             ? RedirectToAction("Login", "Identity")
             : RedirectToAction("Registration", "Identity");
        }

        [HttpGet]
        [Authorize]
        [Route("[action]", Name = "LogOut")]
        public async Task<IActionResult> Logout(string? ReturnUrl)
        {
            await this.signInManager.SignOutAsync();

            return base.RedirectToAction(actionName: "Index", controllerName: "Home");

        }
    }
}