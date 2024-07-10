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
            var query = "Insert into venue_photos (VenueId, PhotoUrlPath) Values (@VenueId, @PhotoUrlPath)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<VenuePhotos>?> GetAllAsync()
        {
            var query = "Select * From venue_photos";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<VenuePhotos>(sql: query);

            return result.ToList();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete From venue_photos Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(VenuePhotos entity)
        {
            var query = "Update venue_photos Set VenueId = @VenueId, PhotoUrlPath = @PhotoUrlPath Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
