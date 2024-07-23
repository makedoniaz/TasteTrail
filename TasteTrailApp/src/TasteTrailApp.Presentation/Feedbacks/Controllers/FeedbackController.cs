using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost(Name = "CreateFeedbackApi")]
    public async Task<IActionResult> Create(CreateFeedbackCommand newFeedback)
    {
        try
        {
            // var validatorResult = this._validator.Validate(instance: newVenue);
            // if (!validatorResult.IsValid)
            // {
            //     foreach (var error in validatorResult.Errors)
            //     {
            //         base.ModelState.AddModelError(key: error.PropertyName, errorMessage: error.ErrorMessage);
            //     }

            //     return base.View(viewName: "Create");
            // }
            newFeedback.VenueId = (int)TempData["VenueId"]!;

            await this.sender.Send(request: newFeedback);
            return Ok();
        }
        catch (Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateFeedbackCommand newFeedback)
    {
        try
        {
            await this.sender.Send(request: newFeedback);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpDelete("{feedbackId:int}")]
    [Authorize]
    public async Task<IActionResult> Delete(int feedbackId)
    {
        try
        {
            var query = new DeleteFeedbackCommand() {
                Id = feedbackId
            };

            await this.sender.Send(query);
            return base.Ok();
        }
        catch (Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }
}
