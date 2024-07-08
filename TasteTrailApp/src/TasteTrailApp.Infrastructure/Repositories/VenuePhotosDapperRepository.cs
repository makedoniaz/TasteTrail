using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class VenuePhotosDapperRepository : IVenuePhotosRepository
    {
        private readonly DapperContext context;

        public VenuePhotosDapperRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(VenuePhotos entity)
        {
            var query = "Insert into Table(VenueId, PhotoUrlPath) Values (@VenueId, @PhotoUrlPath)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<VenuePhotos>> GetAllAsync()
        {
            var query = "Select * From Table";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<VenuePhotos>(sql: query);

            return result.ToList();
        }

        public async Task<int> IDeleteByIdAsync(VenuePhotos id)
        {
            var query = "Delete * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> IPutAsync(VenuePhotos entity)
        {
            var query = "Update Table Set VenueId = @VenueId, PhotoUrlPath = @PhotoUrlPath Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
