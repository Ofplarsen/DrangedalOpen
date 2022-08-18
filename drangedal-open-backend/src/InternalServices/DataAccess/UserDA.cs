using Common.Database;
using Common.Exceptions;
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
                return ReadUserLogin(rdr);
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
                return ReadUser(rdr);
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find user with matching username");
        }

        return null;
    }

    public Player GetPlayer(string username)
    {
        using var con = _connection.Connect();
        try
        {
            using var cmd = new NpgsqlCommand(UserSql.GetPlayer(username), con);
        
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return ReadPlayer(rdr);
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find player with matching username");
        }

        return null;
    }

    private static Player ReadPlayer(NpgsqlDataReader reader)
    {
        return new()
        {
            Ranking = ReadRanking(reader),
            User = ReadUser(reader)
        };
    }

    private static Ranking ReadRanking(NpgsqlDataReader reader)
    {
        return new Ranking()
        {
            Rating = reader.GetInt32(reader.GetOrdinal("rating")),
            GamesLost = reader.GetInt32(reader.GetOrdinal("gameslost")),
            GamesWon = reader.GetInt32(reader.GetOrdinal("gameswon"))
        };
    }
    
    private static User ReadUser(NpgsqlDataReader reader)
    {
        return new User()
        {
            Username = reader["username"] as string,
            FirstName = reader["firstname"] as string,
            LastName = reader["lastname"] as string,
            Email = reader["email"] as string,
            PhoneNumber = reader.GetInt32(reader.GetOrdinal("phonenumber"))
        };
    }

    private static UserLogin ReadUserLogin(NpgsqlDataReader reader)
    {
        string? username = reader["username"] as string;
        string? password = reader["password"] as string;
        return new() {Password = password, Username = username};
    }
}