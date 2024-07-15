using Dapper;

using VenueModel = TasteTrailApp.Core.Venue.Models.Venue;
using TasteTrailApp.Core.Venue.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Venue.Repositories
{
    public class VenueDapperRepository : IVenueRepository
    {
        private readonly DapperContext context;

        public VenueDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(VenueModel entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: 
                @"Insert into venue (Name, Address, Description, ContactNumber, Email, LogoPathUrl, AveragePrice, OverallRating) 
                Values (@Name, @Address, @Description, @ContactNumber, @Email, @LogoPathUrl, @AveragePrice, @OverallRating)", 
                param: entity
            );
        }

        public async Task<List<VenueModel>> GetByCountAsync(int count)
        {
            using var connection = this.context.CreateConnection();
            
            var result = await connection.QueryAsync<VenueModel>(
                sql: $"SELECT * FROM venue LIMIT @Count", 
                param: new { Count = count }
            );

            return result.ToList();
        }

        public async Task<VenueModel?> GetByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<VenueModel>(
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

        public async Task<int> PutAsync(VenueModel entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: $@"Update venue Set Name = @Name, Address = @Address, Description = @Description, 
                        ContactNumber = @ContactNumber, Email = @Email, AveragePrice = @AveragePrice, 
                        OverallRating = @OverallRating Where Id = @Id",
                param: entity
            );
        }

        public async Task<int> CreateAsyncReturningId(VenueModel venue)
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

        public async Task PatchLogoUrlPathAsync(VenueModel venue, string logoUrlPath)
        {
            using var connection = this.context.CreateConnection();

            await connection.ExecuteAsync(
                sql: $@"Update venue Set LogoUrlPath = @LogoUrlPath Where Id = @Id",
                param: new { LogoUrlPath = logoUrlPath, Id = venue.Id }
            );
        }
    }
}
