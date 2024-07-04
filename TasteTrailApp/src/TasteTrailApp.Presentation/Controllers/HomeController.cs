using Microsoft.AspNetCore.Mvc;

namespace TasteTrailApp.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SearchPage()
    {
        return View();
    }

    public IActionResult RestourantDetails()
    {
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }
}
