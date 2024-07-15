using Dapper;

using MenuItemModel = TasteTrailApp.Core.MenuItem.Models.MenuItem;
using TasteTrailApp.Core.MenuItem.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.MenuItem.Repositories
{
    public class MenuItemDapperRepository : IMenuItemRepository
    {
        private readonly DapperContext context;

        public MenuItemDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(MenuItemModel entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Insert into menuitem (Name, Description, Price, PopularityRate, MenuId) Values (@Name, @Description, @Price, @PopularityRate, @MenuId)", 
                param: entity
            );
        }

        public async Task<List<MenuItemModel>> GetByCountAsync(int count)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryAsync<MenuItemModel>(
                sql: $"Select * From menuitem LIMIT @Count", 
                param: new { Count = count }
            );

            return result.ToList();
        }

        public async Task<MenuItemModel?> GetByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<MenuItemModel>(
                sql: "Select * From menuitem Where Id = @Id",
                param: new { Id = id }
            );

            return result;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Delete From menuitem Where Id = @Id",
                param: new { Id = id }
            );
        }

        public async Task<int> PutAsync(MenuItemModel entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Update menuitem Set Name = @Name, Description = @Description, Price = @Price, PopularityRate = @PopularityRate Where Id = @Id",
                param: entity
            );
        }

        public async Task<IEnumerable<MenuItemModel>> GetAllByMenuId(int menuId)
        {
            using var connection = this.context.CreateConnection();

            return await connection.QueryAsync<MenuItemModel>(
                sql: "Select * From menuitem Where menuitem.menuId = @MenuId",
                param: new { MenuId = menuId }
            );
        }
    }
}
