using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class UserRolesDapperRepository : IUserRolesRepository
    {
        private readonly DapperContext context;

        public UserRolesDapperRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(UserRoles entity)
        {
            var query = "Insert into Table(UserId, RoleId) Values (@UserId, @RoleId)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<UserRoles>?> GetByCountAsync(int count)
        {
            var query = $"Select TOP {count} From Table";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<UserRoles>(sql: query);

            return result.ToList();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var query = "Delete * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: id);
        }

        public async Task<int> PutAsync(UserRoles entity)
        {
            var query = "Update Table Set UserId = @UserId, RoleId = @RoleId Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
