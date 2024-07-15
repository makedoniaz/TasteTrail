using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Feedback.Services;

namespace TasteTrailApp.Presentation.Feedback.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }
}
