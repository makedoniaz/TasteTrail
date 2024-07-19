using MediatR;

namespace TasteTrailApp.Core.Feedbacks.Commands;

public class UpdateFeedbackCommand : IRequest
{
    public string? Text { get; set; }

    public int Rating { get; set; }
}
