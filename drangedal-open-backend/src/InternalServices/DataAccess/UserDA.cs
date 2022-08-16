using Common.Database;
using Common.Models;
using Common.Models.Login;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.Sql;
using Npgsql;

namespace InternalServices.DataAccess;

public class UserDA : IUserDA
{
    private readonly IDbConnection _connection;
    public UserDA(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public User CreateUser(UserRegister user)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(UserSql.RegisterUser(user), con);

        cmd.ExecuteNonQuery();
        return null;
    }
}