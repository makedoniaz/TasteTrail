using FeedbackModel = TasteTrailApp.Core.Feedback.Models.Feedback;
using TasteTrailApp.Core.Feedback.Repositories;
using TasteTrailApp.Core.Feedback.Services;

namespace TasteTrailApp.Infrastructure.Feedback.Services;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository feedbackRepository;

    public FeedbackService(IFeedbackRepository feedbackRepository)
    {
        this.feedbackRepository = feedbackRepository;
    }

    public async Task CreateAsync(FeedbackModel feedback)
    {
        var changesCount = await this.feedbackRepository.CreateAsync(feedback);

        if (changesCount == 0)
            throw new InvalidOperationException("Feedback creation didn't apply!");
    }

    public async Task DeleteByIdAsync(int id)
    {
        var changesCount = await this.feedbackRepository.DeleteByIdAsync(id);

        if (changesCount == 0)
            throw new InvalidOperationException("Feedback delete didn't apply!");
    }

    public async Task<List<FeedbackModel>> GetByCountAsync(int count)
    {
        var result = await this.feedbackRepository.GetByCountAsync(count);

        return result;
    }

    public async Task<FeedbackModel> GetByIdAsync(int id)
    {
        var result = await this.feedbackRepository.GetByIdAsync(id);
        ArgumentNullException.ThrowIfNull(result);
        return result;
    }

    public async Task PutAsync(FeedbackModel feedback)
    {
        var changesCount = await this.feedbackRepository.PutAsync(feedback);

        if (changesCount == 0)
            throw new InvalidOperationException("Feedback put didn't apply!");
    }
}
