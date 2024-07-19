using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace TasteTrailApp.Presentation.Feedbacks.Controllers;

[Route("[controller]")]
public class FeedbackController : Controller
{
    private readonly ISender sender;

    public FeedbackController(ISender sender)
    {
        this.sender = sender;
    }

    public IActionResult Index()
    {
        return View();
    }
}
