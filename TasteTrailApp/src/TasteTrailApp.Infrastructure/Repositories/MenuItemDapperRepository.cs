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
            var query = "Insert into MenuItem(Name, Description, Price, PopularityRate, PhotoUrlPath) Values (@Name, @Description, @Price, @PopularityRate, @PhotoUrlPath)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<MenuItem>?> GetByCountAsync(int count)
        {
            var query = $"Select TOP {count} From MenuItem";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<MenuItem>(sql: query);

            return result.ToList();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            var query = "Select * From MenuItem Where Id = @Id";

            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<MenuItem>(sql: query, param: id);

            return result;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete * From MenuItem Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(MenuItem entity)
        {
            var query = "Update MenuItem Set Name = @Name, Description = @Description, Price = @Price, PopularityRate = @PopularityRate, PhotoUrlPath = @PhotoUrlPath Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
