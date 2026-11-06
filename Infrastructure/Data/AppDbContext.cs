using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class AppDbContext
{
    private readonly string connectionString;

    public AppDbContext(string? connectionString = null)
    {
        this.connectionString =
            connectionString
            ?? Environment.GetEnvironmentVariable("BOOKNEST_CONNECTION_STRING")
            ?? "Host=localhost;Port=5432;Database=booknest;Username=postgres";
    }

    public IDbConnection Connection() => new NpgsqlConnection(connectionString);
}
