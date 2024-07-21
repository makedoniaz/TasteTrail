using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Feedbacks.Models;

namespace TasteTrailApp.Presentation.Feedbacks.Controllers;

[Route("[controller]")]
public class FeedbackController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
