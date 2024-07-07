using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TasteTrailApp.Presentation.Controllers
{
    public class VenueController : Controller
    {
        public IActionResult VenueCreation()
        {
            return View();
        }
        
    }
}
