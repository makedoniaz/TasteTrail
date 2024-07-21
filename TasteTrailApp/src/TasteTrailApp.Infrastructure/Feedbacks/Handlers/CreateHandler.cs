using MediatR;
using TasteTrailApp.Core.Feedbacks.Commands;
using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Feedbacks.Repositories;

namespace TasteTrailApp.Infrastructure.Feedbacks.Handlers;

public class CreateHandler : IRequestHandler<CreateFeedbackCommand>
{
    private readonly IFeedbackRepository feedbackRepository;

    public CreateHandler(IFeedbackRepository feedbackRepository)
    {
        this.feedbackRepository = feedbackRepository;
    }

    public async Task Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var newFeedback = new Feedback {
            UserId = request.UserId,
            Text = request.Text,
            Rating = request.Rating,
            CreationDate = DateTime.Now,
            VenueId = request.VenueId
        };

        var changesCount = await feedbackRepository.CreateAsync(newFeedback);

        if (changesCount == 0)
            throw new InvalidOperationException($"{nameof(newFeedback)} creation didn't apply!");
    }
}
