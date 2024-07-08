using Dapper;
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

        public async Task<int> CreateAsync(Feedback entity)
        {
            var query = "Insert into Table(Text, Rating, CreationDate, UserId) Values (@Text, @Rating, @CreationDate, @UserId)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<Feedback>> GetByCountAsync(int count)
        {
            var query = $"Select TOP {count} From Table"; //Может понадобится ORDER BY

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<Feedback>(sql: query);

            return result.ToList();
        }

        public async Task<Feedback?> GetByIdAsync(int id)
        {
            var query = "Select * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<Feedback>(sql: query, param: id);

            return result;
        }

        public async Task<int> DeleteByIdAsync(Feedback id)
        {
            var query = "Delete * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(Feedback entity)
        {
            var query = "Update Table Set Text = @Text, Rating = @Rating, CreationDate = @CreationDate, UserId = @UserId Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
