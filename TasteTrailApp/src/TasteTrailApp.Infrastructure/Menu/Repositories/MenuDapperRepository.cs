using Dapper;

using MenuItemModel = TasteTrailApp.Core.Menu.Models.Menu;
using TasteTrailApp.Core.Menu.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Menu.Repositories
{
    public class MenuDapperRepository : IMenuRepository
    {
        private readonly DapperContext context;

        public MenuDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(MenuItemModel entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Insert into menu (Name, Description, VenueId) Values (@Name, @Description, @VenueId)",
                param: entity
            );
        }

        public async Task<List<MenuItemModel>> GetAllAsync()
        {
            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<MenuItemModel>(
                sql: "Select * From menu"
            );

            return result.ToList();
        }

        public async Task<MenuItemModel?> GetByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<MenuItemModel>(
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

        public async Task<int> PutAsync(MenuItemModel entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Update menu Set Name = @Name, Description = @Description Where Id = @Id",
                param: entity
            );
        }

        public async Task<IEnumerable<MenuItemModel>> GetAllByVenueId(int venueId)
        {
            using var connection = this.context.CreateConnection();

            return await connection.QueryAsync<MenuItemModel>(
                sql: "Select * From menu Where menu.VenueId = @VenueId",
                param: new { VenueId = venueId }
            );
        }
    }
}