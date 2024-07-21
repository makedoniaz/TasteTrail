using MediatR;
using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Feedbacks.Queries;
using TasteTrailApp.Core.Feedbacks.Repositories;

namespace TasteTrailApp.Infrastructure.Feedbacks.Handlers;

public class GetByCountHandler : IRequestHandler<GetFeedbacksByCountQuery, IEnumerable<Feedback>>
{
    private readonly IFeedbackRepository feedbackRepository;

    public GetByCountHandler(IFeedbackRepository feedbackRepository)
    {
        this.feedbackRepository = feedbackRepository;
    }

    public async Task<IEnumerable<Feedback>> Handle(GetFeedbacksByCountQuery request, CancellationToken cancellationToken)
    {
        var count = request.Count;

        return await feedbackRepository.GetByCountAsync(count);
    }
}
