using MediatR;

namespace TasteTrailApp.Core.Feedbacks.Commands;

public class CreateFeedbackCommand : IRequest
{
    public int UserId { get; set; }

    public string? Text { get; set; }

    public int Rating { get; set; }

    public int VenueId { get; set; }
}
