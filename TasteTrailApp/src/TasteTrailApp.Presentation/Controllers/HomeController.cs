using Microsoft.AspNetCore.Mvc;

namespace TasteTrailApp.Presentation.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SearchPage()
    {
        return View();
    }

    public IActionResult VenueDetails()
    {
        return View();
    }

    public IActionResult CreateMenu()
    {
        return View();
    }
    public IActionResult CreateMenuItem()
    {
        return View();
    }
    public IActionResult CreateVenue()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
}
