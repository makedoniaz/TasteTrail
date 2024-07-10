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
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Insert into menuitems_menu (MenuId, MenuItemId) Values (@MenuId, @MenuItemId)",
                param: entity
            );
        }

        public async Task<List<MenuItemMenus>> GetByCountAsync(int count)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryAsync<MenuItemMenus>(
                sql: "Select * From menuitems_menu LIMIT @Count",
                param: new { Count = count }
            );

            return result.ToList();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Delete From menuitems_menu Where Id = @Id",
                param: id
            );
        }

        public async Task<int> PutAsync(MenuItemMenus entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Update menuitems_menu Set MenuId = @MenuId, MenuItemId = @MenuItemId Where Id = @Id",
                param: entity
            );
        }
    }
}
