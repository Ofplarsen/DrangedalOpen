using Common.Database;
using Common.Exceptions;
using Common.Extentions.ReadDb;
using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.SqlQuery;
using Npgsql;
using MatchType = Common.Models.Tournament.MatchType;

namespace InternalServices.DataAccess;

public class MatchDA : IMatchDA
{
    
    private readonly IDbConnection _connection;
    public MatchDA(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public MatchDTO UpdateMatch(MatchDTO match)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(MatchSql.UpdateMatch(match), con);

        cmd.ExecuteNonQuery();
        return match;
    }
    
    public MatchDTO SetMatch(MatchDTO match, bool homeWin)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(MatchSql.SetWinner(match, homeWin), con);

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

    public List<MatchDTO> GetMatches(Guid tournamentId)
    {   
        var con = _connection.Connect();
        var matches = new List<MatchDTO>();
        using (con)
        {

            var cmd = new NpgsqlCommand(TournamentSql.GetMatchesFromTournament(tournamentId), con);
            using (cmd)
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matches.Add(ReadDbObjects.ReadMatchDTO(reader));
                        
                    }
                }
            }
        }

        return matches;
    }
    
    public List<MatchDTO> GetMatchesPlayer(string username)
    {   
        var con = _connection.Connect();
        var matches = new List<MatchDTO>();
        using (con)
        {

            var cmd = new NpgsqlCommand(MatchSql.GetMatchesPlayer(username), con);
            using (cmd)
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matches.Add(ReadDbObjects.ReadMatchDTO(reader));
                        
                    }
                }
            }
        }

        return matches;
    }
    
    public List<MatchDTO> GetMatchesPlayerUpcoming(string username)
    {   
        var con = _connection.Connect();
        var matches = new List<MatchDTO>();
        using (con)
        {

            var cmd = new NpgsqlCommand(MatchSql.GetMatchesPlayerUpcoming(username), con);
            using (cmd)
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matches.Add(ReadDbObjects.ReadMatchDTO(reader));
                        
                    }
                }
            }
        }

        return matches;
    }

    public MatchDTO GetMatch(Guid matchId)
    {
        using var con = _connection.Connect();
        try
        {
            using var cmd = new NpgsqlCommand(MatchSql.GetMatch(matchId), con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                return ReadDbObjects.ReadMatchDTO(rdr);
            }
        }
        catch (Exception e)
        {
            throw new NotFoundException("Didn't find match with matching Id");
        }

        return null;
    }
}