using MediatR;
using TasteTrailApp.Core.Feedbacks.Models;

namespace TasteTrailApp.Core.Feedbacks.Queries;

public class GetFeedbacksByCountQuery : IRequest<IEnumerable<Feedback>>
{
    public int Count { get; set; }
}
