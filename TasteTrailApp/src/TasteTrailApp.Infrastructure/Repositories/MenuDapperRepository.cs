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
            var query = "Insert into menu (Name, Description, CompanyId) Values (@Name, @Description, @CompanyId)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<Menu>?> GetAllAsync()
        {
            var query = "Select * From menu";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<Menu>(sql: query);

            return result.ToList();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            var query = "Select * From menu Where Id = @Id";

            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<Menu>(sql: query, param: id);

            return result;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete From menu Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(Menu entity)
        {
            var query = "Update menu Set Name = @Name, Description = @Description, CompanyId = @CompanyId";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}