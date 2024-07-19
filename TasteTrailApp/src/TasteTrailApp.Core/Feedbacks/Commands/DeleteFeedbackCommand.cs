using MediatR;

namespace TasteTrailApp.Core.Feedbacks.Commands;

public class DeleteFeedbackCommand : IRequest
{
    public int Id { get; set; }
}
