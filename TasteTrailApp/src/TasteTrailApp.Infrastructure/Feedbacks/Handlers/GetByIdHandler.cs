using MediatR;
using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Feedbacks.Queries;
using TasteTrailApp.Core.Feedbacks.Repositories;

namespace TasteTrailApp.Infrastructure.Feedbacks.Handlers;

public class GetByIdHandler : IRequestHandler<GetFeedbackByIdQuery, Feedback>
{
    private readonly IFeedbackRepository feedbackRepository;

    public GetByIdHandler(IFeedbackRepository feedbackRepository)
    {
        this.feedbackRepository = feedbackRepository;
    }

    public async Task<Feedback> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var feedback = await feedbackRepository.GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(feedback);

        return feedback;
    }
}
