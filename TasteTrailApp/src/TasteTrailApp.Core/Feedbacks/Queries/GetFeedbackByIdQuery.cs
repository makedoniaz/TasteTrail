using MediatR;
using TasteTrailApp.Core.Feedbacks.Models;

namespace TasteTrailApp.Core.Feedbacks.Queries;

public class GetFeedbackByIdQuery : IRequest<Feedback>
{
    public int Id { get; set; }
}
