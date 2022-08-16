using Common.Options;
using Npgsql;

namespace Common.Database;

public class DbConnection : IDbConnection
{

    private readonly DatabaseOption _options;

    public DbConnection(DatabaseOption option)
    {
        _options = option;
    }
    
    public NpgsqlConnection Connect()
    {
        var con = new NpgsqlConnection(GetConnectionString());
        con.Open();
        return con;
    }

    private string GetConnectionString()
    {
        return _options.Password != null ? $"Host={_options.Host};Username={_options.Username};Password={_options.Password};Database={_options.Db}" 
            : $"Host={_options.Host};Username={_options.Username};Database={_options.Db}";
    }
}