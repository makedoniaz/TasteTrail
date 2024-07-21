using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Feedbacks.Commands;


namespace TasteTrailApp.Presentation.Feedbacks.Controllers;

[Route("[controller]")]
public class FeedbackController : Controller
{
    private readonly ISender sender;

    public FeedbackController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost]
    [Route("/api/[controller]/[action]", Name = "CreateFeedbackApi")]
    public async Task<IActionResult> CreateFeedback([FromForm] CreateFeedbackCommand command)
    {
        try {
            await sender.Send(command);

            return base.RedirectToAction(actionName: "Index");
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{feedbackId:int}")]
    public async Task<IActionResult> DeleteVenue(int feedbackId)
    {
        try
        {
            var command = new DeleteFeedbackCommand() {
                Id = feedbackId
            };

            await sender.Send(command);
            return base.Ok();
        }
        catch (Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateVenue([FromBody] UpdateFeedbackCommand feedback)
    {
        try
        {
            await this.sender.Send(feedback);
            return base.Ok();
        }
        catch (Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }
}
