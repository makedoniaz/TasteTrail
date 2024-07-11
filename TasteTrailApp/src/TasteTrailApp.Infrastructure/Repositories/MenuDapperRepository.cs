using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class MenuDapperRepository : IMenuRepository
    {
        private readonly DapperContext context;

        public MenuDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(Menu entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Insert into menu (Name, Description, VenueId) Values (@Name, @Description, @VenueId)",
                param: entity
            );
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<Menu>(
                sql: "Select * From menu"
            );

            return result.ToList();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<Menu>(
                sql: "Select * From menu Where Id = @Id",
                param: new { Id = id }
            );

            return result;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Delete From menu Where Id = @Id",
                param: new { Id = id }
            );
        }

        public async Task<int> PutAsync(Menu entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Update menu Set Name = @Name, Description = @Description",
                param: entity
            );
        }

        public async Task<IEnumerable<Menu>> GetAllByVenueId(int venueId)
        {
            using var connection = this.context.CreateConnection();

            return await connection.QueryAsync<Menu>(
                sql: "Select * From menu Where menu.VenueId = @VenueId",
                param: new { VenueId = venueId }
            );
        }
    }
}