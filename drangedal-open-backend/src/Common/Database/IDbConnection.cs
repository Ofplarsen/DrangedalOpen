using Npgsql;

namespace Common.Database;

public interface IDbConnection
{
    public NpgsqlConnection Connect();
}