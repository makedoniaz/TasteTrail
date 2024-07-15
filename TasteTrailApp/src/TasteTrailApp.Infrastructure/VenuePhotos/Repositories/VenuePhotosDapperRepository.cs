using Dapper;

using VenuePhotosModel = TasteTrailApp.Core.VenuePhotos.Models.VenuePhotos;
using TasteTrailApp.Core.VenuePhotos.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.VenuePhotos.Repositories
{
    public class VenuePhotosDapperRepository : IVenuePhotosRepository
    {
        private readonly DapperContext context;

        public VenuePhotosDapperRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(VenuePhotosModel entity)
        {
            var query = "Insert into venue_photos (VenueId, PhotoUrlPath) Values (@VenueId, @PhotoUrlPath)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<VenuePhotosModel>> GetAllAsync()
        {
            var query = "Select * From venue_photos";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<VenuePhotosModel>(sql: query);

            return result.ToList();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete From venue_photos Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(VenuePhotosModel entity)
        {
            var query = "Update venue_photos Set VenueId = @VenueId, PhotoUrlPath = @PhotoUrlPath Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
