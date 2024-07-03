using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class FeedbackDapperRepository : IFeedbackRepository
    {
        private readonly DapperContext context;

        public FeedbackDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public Task<int> CreateAsync(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Feedback>> GetByCountAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> IDeleteByIdAsync(Feedback id)
        {
            throw new NotImplementedException();
        }

        public Task<int> IPutAsync(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
