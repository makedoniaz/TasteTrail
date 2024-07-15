using TasteTrailApp.Core.Common.Repositories.Base;

namespace TasteTrailApp.Core.Feedback.Repositories;

public interface IFeedbackRepository : IGetByCountAsync<Models.Feedback>, IGetByIdAsync<Models.Feedback, int>,
ICreateAsync<Models.Feedback>, IDeleteByIdAsync<int>, IPutAsync<Models.Feedback>
{
    
}
