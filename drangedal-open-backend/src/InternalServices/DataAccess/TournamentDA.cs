using System.Data;
using Common.Exceptions;
using Common.Extentions.ReadDb;
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

    public TournamentDTO GetTournament(Guid tournamentGuid)
    {
        using var con = _connection.Connect();
        try
        {
            using var cmd = new NpgsqlCommand(TournamentSql.GetTournament(tournamentGuid), con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return ReadDbObjects.ReadTournamentDTO(rdr);
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find tournament with matching Id");
        }

        return null;
    }

    public delegate string SqlString();
    public delegate T GetItem<T>(NpgsqlDataReader reader);
    public List<T> GetItemList<T>(SqlString sqlString, GetItem<T> objectReader)
    {
        var con = _connection.Connect();
        var items = new List<T>();
        using (con)
        {

            var cmd = new NpgsqlCommand(sqlString(), con);
            using (cmd)
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(objectReader(reader));
                        
                    }
                }
            }
        }

        return items;
    }
    
    public List<TournamentDTO> GetTournamentsOngoing()
    {
        return GetItemList<TournamentDTO>(TournamentSql.GetTournamentsCurrent,
            ReadDbObjects.ReadTournamentDTO);
    }
    
    public List<TournamentDTO> GetTournamentsArchived()
    {
        return GetItemList<TournamentDTO>(TournamentSql.GetTournamentsArchived,
            ReadDbObjects.ReadTournamentDTO);
    }
}