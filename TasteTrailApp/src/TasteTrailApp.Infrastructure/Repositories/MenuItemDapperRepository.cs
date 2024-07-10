using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class MenuItemDapperRepository : IMenuItemRepository
    {
        private readonly DapperContext context;

        public MenuItemDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(MenuItem entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Insert into menuitem (Name, Description, Price, PopularityRate, MenuId) Values (@Name, @Description, @Price, @PopularityRate, @MenuId)", 
                param: entity
            );
        }

        public async Task<List<MenuItem>> GetByCountAsync(int count)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryAsync<MenuItem>(
                sql: $"Select * From menuitem LIMIT @Count", 
                param: new { Count = count }
            );

            return result.ToList();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<MenuItem>(
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

        public async Task<int> PutAsync(MenuItem entity)
        {
            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(
                sql: "Update menuitem Set Name = @Name, Description = @Description, Price = @Price, PopularityRate = @PopularityRate Where Id = @Id",
                param: entity
            );
        }

        public async Task<IEnumerable<MenuItem>> GetAllByMenuId(int menuId)
        {
            using var connection = this.context.CreateConnection();

            return await connection.QueryAsync<MenuItem>(
                sql: "Select * From menuitem Where menuitem.menuId = @menuId",
                param: menuId
            );
        }
    }
}
