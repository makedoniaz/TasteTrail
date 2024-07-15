namespace TasteTrailApp.Core.Feedback.Services;

public interface IFeedbackService
{
    Task CreateAsync(Models.Feedback feedback);

    Task<List<Models.Feedback>> GetByCountAsync(int count);

    Task<Models.Feedback> GetByIdAsync(int id);

    Task DeleteByIdAsync(int id);

    Task PutAsync(Models.Feedback feedback);
}
