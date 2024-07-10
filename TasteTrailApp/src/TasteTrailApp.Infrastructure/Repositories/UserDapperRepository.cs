using Dapper;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Context;

namespace TasteTrailApp.Infrastructure.Repositories
{
    public class UserDapperRepository : IUserRepository
    {
        private readonly DapperContext context;

        public UserDapperRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(User entity)
        {
            var query = "Insert into Table(Login, Password, Email, AvatarUrlPath, IsActive, IsMuted) Values (@Login, @Password, @Email, @AvatarUrlPath, @IsActive, @IsMuted)";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }

        public async Task<List<User>> GetByCountAsync(int count)
        {
            var query = $"Select * From Table LIMIT {count}";

            using var connection = this.context.CreateConnection();
            var result = await connection.QueryAsync<User>(sql: query);

            return result.ToList();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var query = "Select * From Table Where Id = @Id";

            using var connection = this.context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<User>(sql: query, param: id);

            return result;
        }

        public async Task<int> PutAsync(User entity)
        {
            var query = "Update Table Set Login = @Login, Password = @Password, Email = @Email, AvatarUrlPath = @AvatarUrlPath, IsActive = @IsActive, IsMuted = @IsMuted Where Id = @Id";

            using var connection = this.context.CreateConnection();

            return await connection.ExecuteAsync(sql: query, param: entity);
        }
    }
}
