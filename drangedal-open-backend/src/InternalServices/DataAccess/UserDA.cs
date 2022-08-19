using Common.Database;
using Common.Exceptions;
using Common.Extentions.ReadDb;
using Common.Models;
using Common.Models.Login;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.SqlQuery;
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

    public UserLogin GetUserLogin(string username)
    {
        using var con = _connection.Connect();
        try
        {
            using var cmd = new NpgsqlCommand(UserSql.GetUserLogin(username), con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return ReadDbObjects.ReadUserLogin(rdr);
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find user with matching username");
        }

        return null;
    }

    public User GetUser(string username)
    {
        using var con = _connection.Connect();
        try
        {
            using var cmd = new NpgsqlCommand(UserSql.GetUser(username), con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return ReadDbObjects.ReadUser(rdr);
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find user with matching username");
        }

        return null;
    }
}

    
