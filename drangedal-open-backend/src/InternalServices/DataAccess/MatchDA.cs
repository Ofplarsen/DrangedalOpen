using Common.Database;
using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.SqlQuery;
using Npgsql;

namespace InternalServices.DataAccess;

public class MatchDA : IMatchDA
{
    
    private readonly IDbConnection _connection;
    public MatchDA(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public Match UpdateMatch(Match match)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(MatchSql.UpdateMatch(match), con);

        cmd.ExecuteNonQuery();
        return match;
    }

    public MatchDTO CreateMatch(MatchDTO match)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(MatchSql.CreateMatch(match), con);

        cmd.ExecuteNonQuery();
        return match;
    }
}