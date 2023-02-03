using System.Data;
using Common.Models.DTOs;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.SqlQuery;
using Npgsql;
using IDbConnection = Common.Database.IDbConnection;

namespace InternalServices.DataAccess;

public class TournamentDA : ITournamentDA
{
    private readonly IDbConnection _connection;
    
    public TournamentDA(IDbConnection connection)
    {
        _connection = connection;
    }

    public bool CreateTournament(TournamentDTO tournamentDto)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(TournamentSql.CreateTournament(tournamentDto), con);

        cmd.ExecuteNonQuery();
        return true;
    }
    
    public bool MapTournamentMatch(Guid tournamentGuid, Guid matchGuid)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(TournamentSql.MapTournamentMatch( tournamentGuid, matchGuid), con);

        cmd.ExecuteNonQuery();
        return true;
    }
    
}