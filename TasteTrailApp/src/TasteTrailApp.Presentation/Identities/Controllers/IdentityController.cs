using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TasteTrailApp.Presentation.Common.Dtos;

namespace TasteTrailApp.Presentation.Identities.Controllers
{

    [Route("[controller]")]
    public class IdentityController : Controller
    {

        // private readonly IValidator<Venue> _validator;

        public IdentityController() //IValidator<Venue> validator, 
        {
            // this._validator = validator;
        }

        [HttpGet]
        [Route("[action]", Name = "LoginView")]
        public IActionResult Login(string? ReturnUrl)
        {
            return base.View();
        }

        [HttpPost]
        [Route("/api/[controller]/[action]", Name = "LoginEndPoint")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            return base.RedirectToRoute("LoginView");

        }


        [HttpGet]
        [Route("[action]", Name = "RegistrationView")]
        public IActionResult Registration()
        {
            return base.View();
        }


        [HttpPost]
        [Route("/api/[controller]/[action]", Name = "RegistrationEndpoint")]
        public async Task<IActionResult> Registration([FromForm] RegistrationDto registrationDto)
        {
            return base.RedirectToRoute("RegistrationView");
        }

        [HttpGet]
        [Authorize]
        [Route("[action]", Name = "LogOut")]
        public async Task<IActionResult> Logout(string? ReturnUrl)
        {

            await base.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return base.RedirectToRoute("LoginView", new
            {
                ReturnUrl
            });
        }

    }
}