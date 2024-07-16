using FeedbackModel = TasteTrailApp.Core.Feedback.Models.Feedback;
using TasteTrailApp.Core.Feedback.Repositories;
using TasteTrailApp.Infrastructure.Context;
using TasteTrailApp.Infrastructure.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace TasteTrailApp.Infrastructure.Feedback.Repositories
{
    public class FeedbackEFCoreRepository : IFeedbackRepository
    {
        private readonly TasteTrailDbContext context;

        public FeedbackEFCoreRepository(TasteTrailDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> CreateAsync(FeedbackModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Feedbacks.Add(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var entity = await context.Feedbacks.FindAsync(id);
            if (entity == null)
                throw new ArgumentException($"Entity with id {id} not found.", nameof(id));

            context.Feedbacks.Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<List<FeedbackModel>> GetByCountAsync(int count)
        {
            return await context.Feedbacks
                .OrderByDescending(f => f.CreationDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<FeedbackModel?> GetByIdAsync(int id)
        {
            return await context.Feedbacks.FindAsync(id);
        }

        public async Task<int> PutAsync(FeedbackModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
} 