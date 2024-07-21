using MediatR;
using TasteTrailApp.Core.Feedbacks.Commands;
using TasteTrailApp.Core.Feedbacks.Repositories;

namespace TasteTrailApp.Infrastructure.Feedbacks.Handlers;

public class DeleteHandler : IRequestHandler<DeleteFeedbackCommand>
{
    private readonly IFeedbackRepository feedbackRepository;

    public DeleteHandler(IFeedbackRepository feedbackRepository)
    {
        this.feedbackRepository = feedbackRepository;
    }

    public async Task Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var changesCount = await feedbackRepository.DeleteByIdAsync(id);

        if (changesCount == 0)
            throw new InvalidOperationException($"id: {id} delete didn't apply!");
    }
}
