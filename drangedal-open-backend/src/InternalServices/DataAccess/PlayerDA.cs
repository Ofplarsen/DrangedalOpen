using Common.Database;
using Common.Exceptions;
using Common.Extentions.ReadDb;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.SqlQuery;
using Npgsql;

namespace InternalServices.DataAccess;

public class PlayerDA : IPlayerDA
{
    
    private readonly IDbConnection _connection;
    public PlayerDA(IDbConnection connection)
    {
        _connection = connection;
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
                return ReadDbObjects.ReadPlayer(rdr);
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find player with matching username");
        }

        return null;
    }
    
    public List<Player> GetPlayers()
    {
        using var con = _connection.Connect();
        try
        {
            using var cmd = new NpgsqlCommand(PlayerSql.GetPlayers(), con);
            List<Player> players = new List<Player>();
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                players.Add(ReadDbObjects.ReadPlayer(rdr));
            }

            return players;
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find player with matching username");
        }

        return null;
    }
}