using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class MenuItemMenusDapperRepository : IMenuItemMenusRepository
    {
        private readonly DapperContext context;

        public MenuItemMenusDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(MenuItemMenus entity)
        {
            var query = "Insert into Table(MenuId, MenuItemId) Values (@MenuId, @MenuItemId)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<MenuItemMenus>?> GetByCountAsync(int count)
        {
            var query = $"Select TOP {count} From Table";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<MenuItemMenus>(sql: query);

            return result.ToList();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(MenuItemMenus entity)
        {
            var query = "Update Table Set MenuId = @MenuId, MenuItemId = @MenuItemId Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
