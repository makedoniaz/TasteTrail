using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class VenueDapperRepository : IVenueRepository
    {
        private readonly DapperContext context;

        public VenueDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(Venue entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: 
                @"Insert into venue (Name, Address, Description, ContactNumber, Email, LogoPathUrl, AveragePrice, OverallRating) 
                Values (@Name, @Address, @Description, @ContactNumber, @Email, @LogoPathUrl, @AveragePrice, @OverallRating)", 
                param: entity
            );
        }

        public async Task<List<Venue>> GetByCountAsync(int count)
        {
            using var connection = this.context.CreateConnection();
            
            var result = await connection.QueryAsync<Venue>(
                sql: $"SELECT * FROM venue LIMIT @Count", 
                param: new { Count = count }
            );

            return result.ToList();
        }

        public async Task<Venue?> GetByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<Venue>(
                sql: $"Select * From venue Where Id = @Id",
                param: new { Id = id }
            );

            return result;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: $"Delete From venue Where Id = @Id",
                param: new { Id = id }
            );
        }

        public async Task<int> PutAsync(Venue entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: $@"Update venue Set Name = @Name, Address = @Address, Description = @Description, 
                        ContactNumber = @ContactNumber, Email = @Email, LogoUrlPath = @LogoUrlPath, AveragePrice = @AveragePrice, 
                        OverallRating = @OverallRating Where Id = @Id",
                param: entity
            );
        }

        public async Task<int> CreateAsyncRerturningId(Venue venue)
        {
            using var connection = this.context.CreateConnection();

            var createdId = await connection.ExecuteScalarAsync<int>(
                sql: @"Insert into venue (Name, Address, Description, ContactNumber, Email, AveragePrice, OverallRating) 
                Values (@Name, @Address, @Description, @ContactNumber, @Email, @AveragePrice, @OverallRating)
                RETURNING Id;", 
                param: venue
            );

            return createdId;
        }
    }
}
