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
            var query = @"Insert into Table(Name, Address, Description, ContactNumber, Email, LogoUrlPath, AveragePrice, OverallRating, OwnerId) 
Values (@Name, @Address, @Description, @ContactNumber, @Email, @LogoUrlPath, @AveragePrice, @OverallRating, @OwnerId) ";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<Venue>> GetByCountAsync(int count)
        {
            var query = $"Select TOP {count} From Table";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<Venue>(sql: query);

            return result.ToList();
        }

        public async Task<Venue> GetByIdAsync(int id)
        {
            var query = "Select * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<Venue>(sql: query, param: id);

            return result!;
        }

        public async Task<int> IDeleteByIdAsync(Venue id)
        {
            var query = "Delete * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> IPutAsync(Venue entity)
        {
            var query = @"Update Table Set Name = @Name, Address = @Address, Description = @Description, 
ContactNumber = ContactNumber, Email = @Email, LogoUrlPath = @LogoUrlPath, AveragePrice = @AveragePrice, 
OverallRating = @OverallRating, OwnerId = @OwnerId Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
