using MediatR;
using TasteTrailApp.Core.Feedbacks.Commands;
using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Feedbacks.Repositories;

namespace TasteTrailApp.Infrastructure.Feedbacks.Handlers;

public class UpdateHandler : IRequestHandler<UpdateFeedbackCommand>
{
    private readonly IFeedbackRepository feedbackRepository;

    public UpdateHandler(IFeedbackRepository feedbackRepository)
    {
        this.feedbackRepository = feedbackRepository;
    }

    public async Task Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var newFeedback = new Feedback {
            Text = request.Text,
            Rating = request.Rating,
            CreationDate = DateTime.Now,
        };

        var changesCount = await feedbackRepository.PutAsync(newFeedback);

        if (changesCount == 0)
            throw new InvalidOperationException($"{nameof(newFeedback)} update didn't apply!");
    }
}
