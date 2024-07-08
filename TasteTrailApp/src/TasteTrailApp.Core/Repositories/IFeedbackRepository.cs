using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IFeedbackRepository : IGetByCountAsync<Feedback>, IGetByIdAsync<Feedback, int>,
ICreateAsync<Feedback>, IDeleteByIdAsync<int>, IPutAsync<Feedback>
{
    
}
