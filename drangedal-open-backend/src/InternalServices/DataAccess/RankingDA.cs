using System.Data;
using Common.Models.DTOs;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.Sql;
using Npgsql;
using IDbConnection = Common.Database.IDbConnection;

namespace InternalServices.DataAccess;

public class RankingDA : IRankingDA
{
    
    private readonly IDbConnection _connection;
    public RankingDA(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public bool UpdateRatings(List<PlayerDTO> player)
    {
        using var con = _connection.Connect();

        using var trans = con.BeginTransaction(IsolationLevel.Serializable);

        try
        {
            player.ForEach(p =>
            {
                UpdateRating(p, con, trans);
            });
        }
        catch (Exception e)
        {
            trans.Rollback();
            throw e;
        }
        
        trans.Commit();
        return true;
    }

    private void UpdateRating(PlayerDTO player, NpgsqlConnection con, NpgsqlTransaction transaction)
    {
        using var cmd = new NpgsqlCommand(RankingSql.UpdateRating(player), con, transaction);
        cmd.ExecuteNonQuery();
    }
}