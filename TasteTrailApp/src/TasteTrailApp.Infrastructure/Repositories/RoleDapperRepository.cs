using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class RoleDapperRepository : IRoleRepository
    {
        private readonly DapperContext context;

        public RoleDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(Role entity)
        {
            var query = "Insert into Table(Name) Values (@Name)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var query = "Select * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<Role>(sql: query, param: id);

            return result!;
        }
    }
}
