using Dapper;

using FeedbackModel = TasteTrailApp.Core.Feedback.Models.Feedback;
using TasteTrailApp.Core.Feedback.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Feedback.Repositories
{
    public class FeedbackDapperRepository : IFeedbackRepository
    {
        private readonly DapperContext context;

        public FeedbackDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(FeedbackModel entity)
        {
            var query = "Insert into Table(Text, Rating, CreationDate, UserId) Values (@Text, @Rating, @CreationDate, @UserId)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<FeedbackModel>> GetByCountAsync(int count)
        {
            var query = $"Select * From Table LIMIT {count}"; //Может понадобится ORDER BY

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<FeedbackModel>(sql: query);

            return result.ToList();
        }

        public async Task<FeedbackModel?> GetByIdAsync(int id)
        {
            var query = "Select * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<FeedbackModel>(sql: query, param: id);

            return result;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(FeedbackModel entity)
        {
            var query = "Update Table Set Text = @Text, Rating = @Rating, CreationDate = @CreationDate, UserId = @UserId Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
