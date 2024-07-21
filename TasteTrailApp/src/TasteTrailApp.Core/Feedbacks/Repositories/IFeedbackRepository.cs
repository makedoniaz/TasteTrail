using TasteTrailApp.Core.Common.Repositories.Base;
using TasteTrailApp.Core.Feedbacks.Models;

namespace TasteTrailApp.Core.Feedbacks.Repositories;

public interface IFeedbackRepository : IGetByCountAsync<Feedback>, IGetByIdAsync<Feedback, int>,
ICreateAsync<Feedback>, IDeleteByIdAsync<int>, IPutAsync<Feedback>
{
    
}
