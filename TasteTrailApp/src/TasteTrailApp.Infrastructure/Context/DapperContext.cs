using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using TasteTrailApp.Infrastructure.Extensions;

namespace TasteTrailApp.Infrastructure.Context
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionStringOfThrowArgumentException("SqlConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(this.connectionString);
        }
    }
}