using Npgsql;

namespace SportsClubMembership.Data
{
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory()
        {
            _connectionString =
                "Host=localhost;Port=5432;Username=postgres;Password=2506;Database=postgres;";
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
