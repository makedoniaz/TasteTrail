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
            var query = "Insert into menuitems_menu (MenuId, MenuItemId) Values (@MenuId, @MenuItemId)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<MenuItemMenus>> GetByCountAsync(int count)
        {
            var query = $"Select TOP {count} * From menuitems_menu";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<MenuItemMenus>(sql: query);

            return result.ToList();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete From menuitems_menu Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(MenuItemMenus entity)
        {
            var query = "Update menuitems_menu Set MenuId = @MenuId, MenuItemId = @MenuItemId Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
